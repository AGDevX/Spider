using System.Linq;
using AGDevX.Assemblies;
using AGDevX.Spider.Web.Config;
using AGDevX.Web.Swagger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AGDevX.Spider.Web.Startup
{
    public static class Services
    {
        public static ApiConfig ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var apiConfig = services.ConfigureDependencyInjection(configuration);

            services.AddDefaultCorsPolicy(apiConfig);
            services.AddEndpointsApiExplorer();
            services.AddApiVersioning();
            services.AddSwaggerToApi(apiConfig);
            services.AddControllers();

            return apiConfig;
        }

        public static ApiConfig ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            var apiConfig = services.ConfigureConfigDependencyInjection(configuration);

            services.ConfigureSolutionDependencyInjection(apiConfig);

            return apiConfig;
        }

        public static ApiConfig ConfigureConfigDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            var apiConfig = configuration.GetSection("ApiConfig").Get<ApiConfig>();
            
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
                Title = apiConfig.Api.Name,
                Description = apiConfig.Api.Description
            };

            services.AddSwaggerToApi(swaggerConfig);
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
    }
}