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

        var apiConfig = builder.Services.GetApiConfig(configuration);

        builder.Services.ConfigureDependencyInjection(apiConfig);
        builder.Services.ConfigureSecurity(apiConfig);
        builder.Services.ConfigureAuth(configuration, apiConfig);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.ConfigureApiVersioning();
        builder.Services.ConfigureJson();
        builder.Services.ConfigureSwagger(apiConfig);
        builder.Services.ConfigureAutoMapper(apiConfig);
        builder.Services.AddControllers();

        return apiConfig;
    }

    private static void ConfigureLogging(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, services, configuration) => configuration
                    .ReadFrom.Configuration(context.Configuration)
                    .ReadFrom.Services(services));
    }

    private static ApiConfig GetApiConfig(this IServiceCollection services, IConfiguration configuration)
    {
        return configuration.GetRequiredSection("ApiConfig").Get<ApiConfig>()
                ?? throw new ApplicationStartupException("An exception occurred while retrieving the ApiConfig section");
    }

    private static void ConfigureDependencyInjection(this IServiceCollection services, ApiConfig apiConfig)
    {
        services.AddSingleton(apiConfig);
        services.ConfigureDependencyInjectionForSolution(apiConfig);
        services.ConfigureDependencyInjectionForDbConnection(apiConfig);
    }

    private static void ConfigureDependencyInjectionForSolution(this IServiceCollection services, ApiConfig apiConfig)
    {
        var assemblies = AssemblyUtility.GetAssemblies(null, apiConfig.Solution.AssemblyPrefixes);

        services.Scan(scan => scan.FromAssemblies(assemblies)
                                  .AddClasses()
                                  .AsMatchingInterface()
                                  .WithScopedLifetime());
    }

    private static void ConfigureDependencyInjectionForDbConnection(this IServiceCollection services, ApiConfig apiConfig)
    {
        services.AddSingleton(apiConfig.Database);
        services.AddSingleton(new DatabaseConnection
        {
            ConnectionString = apiConfig.Database.ConnectionString
        });
    }

    private static void ConfigureSecurity(this IServiceCollection services, ApiConfig apiConfig)
    {
        services.ConfigureCorsPolicy(apiConfig);
        services.AddScoped<IClaimsTransformation, AddUserIdentityClaimsTransformation>();
    }

    private static void ConfigureCorsPolicy(this IServiceCollection services, ApiConfig apiConfig)
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

    private static void ConfigureAuth(this IServiceCollection services, IConfiguration configuration, ApiConfig apiConfig)
    {
        services.ConfigureAuth0(configuration, apiConfig.Auth);
        services.ConfigureOAuth(apiConfig.Auth);
    }

    private static void ConfigureOAuth(this IServiceCollection services, AuthProviderConfig authConfig)
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

    private static void ConfigureApiVersioning(this IServiceCollection services)
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

    private static void ConfigureJson(this IServiceCollection services)
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

    private static void ConfigureSwagger(this IServiceCollection services, ApiConfig apiConfig)
    {
        var swaggerConfig = new SwaggerConfig
        {
            Enabled = apiConfig.Api.EnableSwagger,
            ApiXmlDocumentationFilename = apiConfig.Api.ApiXmlDocumentationFilename ?? $"{Assembly.GetExecutingAssembly().GetName().Name}.xml",
            Author = apiConfig.Api.Author,
            AuthorEmail = apiConfig.Api.AuthorEmail,
            AuthorUrl = apiConfig.Api.AuthorUrl,
            Title = apiConfig.Api.Name,
            Description = apiConfig.Api.Description,
            AuthorizationUrl = apiConfig.Auth.OAuth.AuthorizationUrl,
            TokenUrl = apiConfig.Auth.OAuth.TokenUrl,
            ClientId = apiConfig.Auth.OAuth.ClientId,
            ClientSecret = apiConfig.Auth.OAuth.ClientSecret,
            Scopes = apiConfig.Auth.OAuth.ApiScopes.Concatenate(apiConfig.Auth.Oidc.Scopes).ReverseKeysAndValues() ?? new Dictionary<string, string>()
        };

        services.AddSwaggerToApi(swaggerConfig);
    }

    private static void ConfigureAutoMapper(this IServiceCollection services, ApiConfig apiConfig)
    {
        var assemblies = AssemblyUtility.GetAssemblies(null, apiConfig.Solution.AssemblyPrefixes);

        services.AddAutoMapper(assemblies);
    }
}