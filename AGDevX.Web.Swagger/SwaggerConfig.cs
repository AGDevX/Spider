using System;
using System.Collections.Generic;

namespace AGDevX.Web.Swagger
{
    public sealed class SwaggerConfig
    {
        public bool Enabled { get; set; } = true;
        public string Author { get; set; } = "AGDevX";
        public string AuthorEmail { get; set; } = "AGDevX@gmail.com";
        public Uri AuthorUrl { get; set; } = new Uri("https://github.com/AGDevX");
        public string Title { get; set; } = ".NET Web API";
        public string Description { get; set; } = "RESTful .NET Web API";
        public Uri? AuthorizationUrl { get; set; }
        public Uri? TokenUrl { get; set; }
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public Dictionary<string, string> Scopes { get; set; } = new Dictionary<string, string>();
    }
}