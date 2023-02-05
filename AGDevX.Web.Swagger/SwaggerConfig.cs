using System;
using System.Collections.Generic;

namespace AGDevX.Web.Swagger
{
    public sealed class SwaggerConfig
    {
        public bool Enabled { get; set; } = true;
        public string? Author { get; set; }
        public string? AuthorEmail { get; set; }
        public Uri? AuthorUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Uri? AuthorizationUrl { get; set; }
        public Uri? TokenUrl { get; set; }
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public Dictionary<string, string> Scopes { get; set; } = new Dictionary<string, string>();
    }
}