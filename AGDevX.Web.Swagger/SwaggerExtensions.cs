using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;

namespace AGDevX.Web.Swagger
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerToApi(this IServiceCollection services, SwaggerConfig swaggerConfig)
        {
            services.AddSingleton(swaggerConfig);
            services.AddSwaggerGen();
            services.ConfigureOptions<ConfigureSwaggerOptions>();
        }

        public static void UseSwaggerForApi(this WebApplication webApp)
        {
            var apiVersionDescriptionProvider = webApp.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            webApp.UseSwagger();
            webApp.UseSwaggerUI(options =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
                {
                    options.SwaggerEndpoint($"/swagger/{ description.GroupName }/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });
        }
    }
}