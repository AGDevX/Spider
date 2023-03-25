using System;
using AGDevX.Database.Config;
using AGDevX.Enums;
using AGDevX.Environments;
using AGDevX.Exceptions;
using AGDevX.Web.Auth;
using AGDevX.Web.Auth0;

namespace AGDevX.Spider.WebApi.Config;

public sealed class ApiConfig
{
    public EnvironmentType Environment { get; set; } = EnvironmentType.Local;
    public BaseConfig Api { get; set; } = new BaseConfig();
    public DatabaseConfig Database { get; set; } = new DatabaseConfig();
    public SolutionConfig Solution { get; set; } = new SolutionConfig();
    public SecurityConfig Security { get; set; } = new SecurityConfig();
    public AuthConfig Auth { get; set; } = new AuthConfig();

    public sealed class BaseConfig
    {
        public string? Author { get; set; }
        public string? AuthorEmail { get; set; }
        public string? AuthorUrl { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool EnableSwagger { get; set; }
        public string? ApiXmlDocumentationFilename { get; set; }
        public bool AutoCreateUsers { get; set; }
        public bool NewUsersActiveByDefault { get; set; }
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

    public sealed class AuthConfig
    {
        public AuthProvider? Provider { get; set; }
        public Auth0ProviderConfig? Auth0 { private get; set; }

        public AuthProviderConfig Config => Provider switch
        {
            AuthProvider.Auth0 => Auth0 ?? throw new AuthProviderException($"{ Provider.StringValue() } has not been configured"),
            _ => throw new AuthProviderException(string.Format("{0} auth provider has not been configured{1}", Provider.HasValue ? "This" : "An", Provider.HasValue ? $"'{ Provider.StringValue() }'" : ""))
        };
    }
}