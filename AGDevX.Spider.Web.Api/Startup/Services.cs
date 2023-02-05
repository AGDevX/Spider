using System;
using System.Linq;
using AGDevX.Assemblies;
using AGDevX.Database.Connections;
using AGDevX.Exceptions;
using AGDevX.Spider.Web.Api.AuthN;
using AGDevX.Spider.Web.Api.Config;
using AGDevX.Spider.Web.Api.Startup;
using AGDevX.Strings;
using AGDevX.Web.AuthN.OAuth;
using AGDevX.Web.Swagger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AGDevX.Spider.Web.Api.Startup
{
    public static class Services
    {
        public static ApiConfig ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var apiConfig = services.ConfigureDependencyInjection(configuration);

            services.AddDefaultCorsPolicy(apiConfig);
            services.AddOAuth(apiConfig);
            services.AddEndpointsApiExplorer();
            services.AddApiVersioning();
            services.AddSwaggerToApi(apiConfig);
            services.AddAutoMapper(apiConfig);
            services.AddControllers();

            return apiConfig;
        }

        public static ApiConfig ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            var apiConfig = services.ConfigureConfigDependencyInjection(configuration);

            services.ConfigureSolutionDependencyInjection(apiConfig);
            services.ConfigureDbConnectionDependencyInjection(apiConfig);

            return apiConfig;
        }

        public static ApiConfig ConfigureConfigDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            var apiConfig = configuration.GetRequiredSection("ApiConfig").Get<ApiConfig>()
                ?? throw new ApplicationStartupException("An exception occurred while retrieving the ApiConfig section");

            services.AddSingleton(apiConfig);

            return apiConfig;
        }

        public static void ConfigureSolutionDependencyInjection(this IServiceCollection services, ApiConfig apiConfig)
        {
            var assemblies = AssemblyUtility.GetAssemblies(null, apiConfig.Solution.AssemblyPrefixes);

            services.Scan(scan => scan.FromAssemblies(assemblies)
                                      .AddClasses()
                                      .AsMatchingInterface()
                                      .WithScopedLifetime());
        }

        public static void ConfigureDbConnectionDependencyInjection(this IServiceCollection services, ApiConfig apiConfig)
        {
            services.AddScoped<IDbConnectionProvider>(serviceProvider => {
                return new SqlServerConnectionProvider(apiConfig.Api.ConnectionString);
            });
        }

        public static void AddDefaultCorsPolicy(this IServiceCollection services, ApiConfig apiConfig)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(apiConfig.Security.CorsPolicy, builder =>
                {
                    var allowedOrigins = apiConfig.Security.AllowedOrigins;
                    var allowedHeaders = apiConfig.Security.AllowedHeaders;
                    var allowedMethods = apiConfig.Security.AllowedMethods;

                    //-- Origins
                    if (allowedOrigins.Contains("*"))
                    {
                        builder.AllowAnyOrigin();
                    }
                    else
                    {
                        builder.WithOrigins(allowedOrigins);
                    }

                    //-- Methods
                    if (allowedMethods.Contains("*"))
                    {
                        builder.AllowAnyMethod();
                    }
                    else
                    {
                        builder.WithMethods(allowedMethods);
                    }

                    //-- Headers
                    if (allowedHeaders.Contains("*"))
                    {
                        builder.AllowAnyHeader();
                    }
                    else
                    {
                        builder.WithHeaders(allowedHeaders);
                    }
                });
            });
        }

        public static void AddOAuth(this IServiceCollection services, ApiConfig apiConfig)
        {
            var jwtOAuthConfig = new JwtOAuthConfig
            {
                AuthenticationScheme = apiConfig.AuthN.OAuth.AuthenticationScheme,
                Authority = apiConfig.AuthN.OAuth.Authority,
                Issuer = apiConfig.AuthN.OAuth.Issuer,
                Audience = apiConfig.AuthN.OAuth.Audience,
                RequireHttpsMetadata = apiConfig.AuthN.OAuth.RequireHttpsMetadata,
                OpenIDConnectDiscoveryUrl = apiConfig.AuthN.OAuth.OpenIDConnectDiscoveryUrl
            };

            var jwtBearerEvents = new JwtBearerEventsOverrides();
            services.AddJwtOAuth(jwtOAuthConfig, jwtBearerEvents);
        }

        public static void AddApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                    new HeaderApiVersionReader("x-api-version"),
                                                                    new MediaTypeApiVersionReader("x-api-version"));
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }

        public static void AddSwaggerToApi(this IServiceCollection services, ApiConfig apiConfig)
        {
            var swaggerConfig = new SwaggerConfig
            {
                Enabled = apiConfig.Api.EnableSwagger,
                Author = apiConfig.Api.Author,
                AuthorEmail = apiConfig.Api.AuthorEmail,
                AuthorUrl = new Uri(apiConfig.Api.AuthorUrl),
                Title = apiConfig.Api.Name,
                Description = apiConfig.Api.Description,
                AuthorizationUrl = new Uri(apiConfig.AuthN.OAuth.AuthorizationUrl),
                TokenUrl = new Uri(apiConfig.AuthN.OAuth.TokenUrl),
                ClientId = apiConfig.AuthN.OAuth.ApiClient.ClientId,
                ClientSecret = apiConfig.AuthN.OAuth.ApiClient.ClientSecret,
                Scopes = apiConfig.AuthN.OAuth.ApiScopes.ReverseKeysAndValues()
            };

            services.AddSwaggerToApi(swaggerConfig);
        }

        public static void AddAutoMapper(this IServiceCollection services, ApiConfig apiConfig)
        {
            var assemblies = AssemblyUtility.GetAssemblies(null, apiConfig.Solution.AssemblyPrefixes);

            services.AddAutoMapper(assemblies);
        }
    }
}