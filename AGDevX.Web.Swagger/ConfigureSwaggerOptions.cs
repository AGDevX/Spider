using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AGDevX.Web.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        private readonly SwaggerConfig _swaggerConfig;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, SwaggerConfig swaggerConfig)
        {
            _provider = provider;
            _swaggerConfig = swaggerConfig;
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription apiVersionDescription)
        {
            var openApiInfo = new OpenApiInfo()
            {
                Title = _swaggerConfig.Title,
                Description = _swaggerConfig.Description,
                Version = apiVersionDescription.ApiVersion.ToString()
            };

            if (apiVersionDescription.IsDeprecated)
            {
                openApiInfo.Description += "This version of the API is deprecated.";
            }

            return openApiInfo;
        }
    }
}