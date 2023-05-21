using System.Collections.Generic;
using AGDevX.IEnumerables;
using AGDevX.Strings;

namespace AGDevX.Web.Swagger;

public sealed class SwaggerConfig
{
    public bool Enabled { get; set; } = true;
    public string? ApiXmlDocumentationFilename { get; set; }
    public string? Author { get; set; }
    public string? AuthorEmail { get; set; }
    public string? AuthorUrl { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? AuthorizationUrl { get; set; }
    public string? TokenUrl { get; set; }
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public Dictionary<string, string> Scopes { get; set; } = new Dictionary<string, string>();
}

public static class SwaggerConfigExtensions
{
    public static bool IsConfiguredForOAuth2(this SwaggerConfig swaggerConfig)
    {
        return swaggerConfig.AuthorizationUrl.IsNotNullNorWhiteSpace()
                && swaggerConfig.TokenUrl.IsNotNullNorWhiteSpace()
                && swaggerConfig.ClientId.IsNotNullNorWhiteSpace()
                && swaggerConfig.ClientSecret.IsNotNullNorWhiteSpace()
                && swaggerConfig.Scopes.AnySafe();
    }
}