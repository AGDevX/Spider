using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using AGDevX.Assemblies;
using AGDevX.Database.Connections;
using AGDevX.Exceptions;
using AGDevX.IEnumerables;
using AGDevX.Spider.WebApi.AuthN;
using AGDevX.Spider.WebApi.AuthZ;
using AGDevX.Spider.WebApi.Config;
using AGDevX.Spider.WebApi.Startup;
using AGDevX.Strings;
using AGDevX.Web.Auth;
using AGDevX.Web.Auth.AuthZ.OAuth;
using AGDevX.Web.AuthZ.OAuth;
using AGDevX.Web.Swagger;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Serilog;

namespace AGDevX.Spider.WebApi.Startup;

public static class Services
{
    public static ApiConfig ConfigureServices(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.ConfigureLogging();

        var apiConfig = builder.Services.ConfigureDependencyInjection(configuration);

        builder.Services.AddDefaultCorsPolicy(apiConfig);
        builder.Services.AddSecurity(apiConfig);
        builder.Services.AddAuth(configuration, apiConfig);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddApiVersioning();
        builder.Services.ConfigureJson();
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
        services.AddSingleton(apiConfig.Database);

        if (apiConfig.Database.UseDatabase && apiConfig.Database.SqlServerConnectionString.IsNotNullOrWhiteSpace())
        {
            services.AddSingleton(new DatabaseConnection
            {
                SqlServerConnectionString = apiConfig.Database.SqlServerConnectionString
            });
        }
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
        services.AddScoped<IClaimsTransformation, AddUserIdentityClaimsTransformation>();
    }

    public static void AddAuth(this IServiceCollection services, IConfiguration configuration, ApiConfig apiConfig)
    {
        var auth0ProviderConfig = services.AddAuth0(configuration);

        if (auth0ProviderConfig != null)
        {
            apiConfig.Auth.Auth0 = auth0ProviderConfig;
            var authConfig = apiConfig.Auth.Config;
            services.AddOAuth(authConfig);
        }
    }

    public static void AddOAuth(this IServiceCollection services, AuthProviderConfig? authConfig)
    {
        if (authConfig != null)
        {
            var jwtOAuthConfig = new JwtOAuthConfig
            {
                AuthenticationScheme = authConfig.OAuth.AuthenticationScheme,
                NameClaimType = authConfig.OAuth.NameClaimType,
                RoleClaimType = authConfig.OAuth.RoleClaimType,
                Authority = authConfig.OAuth.Authority,
                Issuer = authConfig.OAuth.Issuer,
                Audience = authConfig.OAuth.Audience,
                RequireHttpsMetadata = authConfig.Oidc.RequireHttpsMetadata,
                OpenIDConnectDiscoveryUrl = authConfig.Oidc.OpenIDConnectDiscoveryUrl
            };

            var jwtBearerEvents = new JwtBearerEventsOverrides();
            services.AddJwtOAuth(jwtOAuthConfig, jwtBearerEvents);
        }
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

    public static void ConfigureJson(this IServiceCollection services)
    {
        services.Configure<JsonOptions>(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.SerializerOptions.AllowTrailingCommas = false;
            options.SerializerOptions.PropertyNameCaseInsensitive = true;
            options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.SerializerOptions.WriteIndented = true;
            options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
        
        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = new List<Newtonsoft.Json.JsonConverter> { new StringEnumConverter() }
        };
    }

    public static void AddSwaggerToApi(this IServiceCollection services, ApiConfig apiConfig)
    {
        var authConfig = apiConfig.Auth.Config;

        var swaggerConfig = new SwaggerConfig
        {
            Enabled = apiConfig.Api.EnableSwagger,
            ApiXmlDocumentationFilename = apiConfig.Api.ApiXmlDocumentationFilename ?? $"{Assembly.GetExecutingAssembly().GetName().Name}.xml",
            Author = apiConfig.Api.Author,
            AuthorEmail = apiConfig.Api.AuthorEmail,
            AuthorUrl = apiConfig.Api.AuthorUrl,
            Title = apiConfig.Api.Name,
            Description = apiConfig.Api.Description,
            AuthorizationUrl = authConfig?.OAuth.AuthorizationUrl,
            TokenUrl = authConfig?.OAuth.TokenUrl,
            ClientId = authConfig?.OAuth.ClientId,
            ClientSecret = authConfig?.OAuth.ClientSecret,
            Scopes = authConfig?.OAuth.ApiScopes.Concatenate(authConfig.Oidc.Scopes).ReverseKeysAndValues() ?? new Dictionary<string, string>()
        };

        services.AddSwaggerToApi(swaggerConfig);
    }

    public static void AddAutoMapper(this IServiceCollection services, ApiConfig apiConfig)
    {
        var assemblies = AssemblyUtility.GetAssemblies(null, apiConfig.Solution.AssemblyPrefixes);

        services.AddAutoMapper(assemblies);
    }
}