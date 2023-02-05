using AGDevX.Core.Swagger.OperationFilter;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AGDevX.Web.Swagger
{
    public class ConfigureOAuth2SwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly string _scheme = "OAuth2";

        private readonly IApiVersionDescriptionProvider _provider;
        private readonly SwaggerConfig _swaggerConfig;

        public ConfigureOAuth2SwaggerOptions(IApiVersionDescriptionProvider provider, SwaggerConfig swaggerConfig)
        {
            _provider = provider;
            _swaggerConfig = swaggerConfig;
        }

        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
            
            options.OperationFilter<AuthorizeOperationFilter>(_scheme);

            options.DescribeAllParametersInCamelCase();
            options.CustomSchemaIds(x => x.FullName);

            options.AddSecurityDefinition(_scheme, new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows()
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = _swaggerConfig.AuthorizationUrl,
                        TokenUrl = _swaggerConfig.TokenUrl,
                        Scopes = _swaggerConfig.Scopes
                    }
                },
                Description = $"{ _scheme } - PKCE"
            });
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription apiVersionDescription)
        {
            var openApiInfo = new OpenApiInfo()
            {
                Title = _swaggerConfig.Title,
                Description = _swaggerConfig.Description,
                Version = apiVersionDescription.ApiVersion.ToString(),
                Contact = new OpenApiContact
                {
                    Name = _swaggerConfig.Author,
                    Email = _swaggerConfig.AuthorEmail,
                    Url = _swaggerConfig.AuthorUrl
                }
            };

            if (apiVersionDescription.IsDeprecated)
            {
                openApiInfo.Description += "This version of the API is deprecated.";
            }

            return openApiInfo;
        }
    }
}