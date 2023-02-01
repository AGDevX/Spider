using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AGDevX.Web.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerToApi(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            
            return services;
        }

        public static WebApplication UseSwaggerForApi(this WebApplication webApp)
        {
            webApp.UseSwagger();
            webApp.UseSwaggerUI();

            return webApp;
        }
    }
}