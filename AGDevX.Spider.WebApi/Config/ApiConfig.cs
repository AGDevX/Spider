using System;
using AGDevX.Database.Config;
using AGDevX.Environments;
using AGDevX.Web.Auth0;

namespace AGDevX.Spider.WebApi.Config;

public sealed class ApiConfig
{
    public EnvironmentType Environment { get; set; } = EnvironmentType.Local;
    public required BaseApiConfig Api { get; set; }
    public required DatabaseConfig Database { get; set; }
    public required SolutionConfig Solution { get; set; }
    public required SecurityConfig Security { get; set; }
    public required Auth0ProviderConfig Auth { get; set; }

    public sealed class BaseApiConfig
    {
        public string? Author { get; set; }
        public string? AuthorEmail { get; set; }
        public string? AuthorUrl { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool EnableSwagger { get; set; }
        public string? ApiXmlDocumentationFilename { get; set; }
        public bool AutoCreateUsers { get; set; } = true;
        public bool NewUsersActiveByDefault { get; set; } = true;
        public Guid SystemUserId { get; set; }
    }

    public sealed class SolutionConfig
    {
        public string[] AssemblyPrefixes { get; set; } = Array.Empty<string>();
    }

    public sealed class SecurityConfig
    {
        public string CorsPolicy { get; set; } = "DefaultCorsPolicy";
        public string[] AllowedOrigins { get; set; } = Array.Empty<string>();
        public string[] AllowedMethods { get; set; } = Array.Empty<string>();
        public string[] AllowedHeaders { get; set; } = Array.Empty<string>();
    }
}