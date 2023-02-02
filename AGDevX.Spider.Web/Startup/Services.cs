using System.Linq;
using AGDevX.Assemblies;
using AGDevX.Spider.Web.Config;
using AGDevX.Web.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AGDevX.Spider.Web.Startup
{
    public static class Services
    {
        public static ApiConfig ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var apiConfig = services.ConfigureDependencyInjection(configuration);

            services.ConfigureCors(apiConfig);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerToApi();

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

        public static void ConfigureCors(this IServiceCollection services, ApiConfig apiConfig)
        {
            var DEFAULT_CORS_POLICY = "DefaultCorsPolicy";

            services.AddCors(options =>
            {
                options.AddPolicy(DEFAULT_CORS_POLICY, builder =>
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