using System;
using AGDevX.Environments;
using AGDevX.Web.AuthN.Oidc;
using AGDevX.Web.AuthZ.OAuth;

namespace AGDevX.Spider.WebApi.Config
{
    public sealed class ApiConfig
    {
        public EnvironmentType Environment { get; set; } = EnvironmentType.Local;
        public Api Api { get; set; } = new Api();
        public Database Database { get; set; } = new Database();
        public Solution Solution { get; set; } = new Solution();
        public Security Security { get; set; } = new Security();
        public Auth Auth { get; set; } = new Auth();
    }

    public sealed class Api
    {
        public string Author { get; set; } = "AGDevX";
        public string AuthorEmail { get; set; } = "AGDevX@gmail.com";
        public string AuthorUrl { get; set; } = "https://github.com/AGDevX";
        public string Name { get; set; } = "Spider Api";
        public string Description { get; set; } = "RESTful .NET API seed application";
        public bool EnableSwagger { get; set; } = true;
        public string? ApiXmlDocumentationFilename { get; set; }
        public bool AutoCreateUsers { get; set; }
        public bool NewUsersActiveByDefault { get; set; }
        public Guid SystemUserId { get; set; }
    }

    public sealed class Database
    {
        public string SqlServerConnectionString { get; set; } = string.Empty;
    }

    public sealed class Solution
    {
        public string[] AssemblyPrefixes { get; set; } = Array.Empty<string>();
    }

    public sealed class Security
    {
        public string CorsPolicy { get; set; } = "DefaultCorsPolicy";
        public string[] AllowedOrigins { get; set; } = Array.Empty<string>();
        public string[] AllowedMethods { get; set; } = Array.Empty<string>();
        public string[] AllowedHeaders { get; set; } = Array.Empty<string>();
    }

    public sealed class Auth
    {
        public OAuthProviderConfig OAuth { get; set; } = new OAuthProviderConfig();
        public OidcProviderConfig Oidc { get; set; } = new OidcProviderConfig();
    }
}