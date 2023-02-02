using AGDevX.Assemblies;
using AGDevX.Spider.Web.Config;
using AGDevX.Web.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AGDevX.Spider.Web.Startup
{
    public static class Services
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerToApi();
            services.ConfigureDependencyInjection(configuration);

            return services;
        }

        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            var apiConfig = services.ConfigureConfigDependencyInjection(configuration);
            services.ConfigureSolutionDependencyInjection(apiConfig);

            return services;
        }

        public static ApiConfig ConfigureConfigDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            var apiConfig = configuration.GetSection("ApiConfig").Get<ApiConfig>();
            services.AddSingleton(apiConfig);

            return apiConfig;
        }

        public static IServiceCollection ConfigureSolutionDependencyInjection(this IServiceCollection services, ApiConfig apiConfig)
        {
            var assemblies = AssemblyUtility.GetAssemblies(null, apiConfig.Solution.AssemblyPrefixes);

            services.Scan(scan => scan.FromAssemblies(assemblies)
                                      .AddClasses()
                                      .AsMatchingInterface()
                                      .WithScopedLifetime());

            return services;
        }
    }
}