using System;
using System.Linq;
using AGDevX.Assemblies;
using AGDevX.Database.Connections;
using AGDevX.Exceptions;
using AGDevX.IEnumerables;
using AGDevX.Spider.WebApi.AuthN;
using AGDevX.Spider.WebApi.Config;
using AGDevX.Spider.WebApi.Startup;
using AGDevX.Web.AuthN.OAuth;
using AGDevX.Web.AuthZ;
using AGDevX.Web.Swagger;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace AGDevX.Spider.WebApi.Startup
{
    public static class Services
    {
        public static ApiConfig ConfigureServices(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            builder.ConfigureLogging();

            var apiConfig = builder.Services.ConfigureDependencyInjection(configuration);

            builder.Services.AddDefaultCorsPolicy(apiConfig);
            builder.Services.AddSecurity(apiConfig);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddApiVersioning();
            builder.Services.AddSwaggerToApi(apiConfig);
            builder.Services.AddAutoMapper(apiConfig);
            builder.Services.AddControllers();

            return apiConfig;
        }

        public static void ConfigureLogging(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, services, configuration) => configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services));
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
            services.AddSingleton(new DatabaseConnection { ConnectionString = apiConfig.Api.ConnectionString });
            services.AddScoped<IDbConnectionProvider, SqlServerConnectionFactory>();
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

                    builder.Build();
                });
            });
        }

        public static void AddSecurity(this IServiceCollection services, ApiConfig apiConfig)
        {
            services.AddOAuth(apiConfig);
            services.AddScoped<IClaimsTransformation, AddUserIdentityClaimsTransformation>();
            services.AddScoped<LogAuthorizeAttributeActionFilter>();
        }

        public static void AddOAuth(this IServiceCollection services, ApiConfig apiConfig)
        {
            var jwtOAuthConfig = new JwtOAuthConfig
            {
                AuthenticationScheme = apiConfig.AuthN.OAuth.AuthenticationScheme,
                NameClaimType = apiConfig.AuthN.OAuth.NameClaimType,
                RoleClaimType = apiConfig.AuthN.OAuth.RoleClaimType,
                Authority = apiConfig.AuthN.OAuth.Authority,
                Issuer = apiConfig.AuthN.OAuth.Issuer,
                Audience = apiConfig.AuthN.OAuth.Audience,
                RequireHttpsMetadata = apiConfig.AuthN.Oidc.RequireHttpsMetadata,
                OpenIDConnectDiscoveryUrl = apiConfig.AuthN.Oidc.OpenIDConnectDiscoveryUrl
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
            var apiScopes = apiConfig.AuthN.OAuth.ApiScopes;
            var oidcScopes = apiConfig.AuthN.Oidc.Scopes;

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
                Scopes = apiScopes.Concatenate(oidcScopes)
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