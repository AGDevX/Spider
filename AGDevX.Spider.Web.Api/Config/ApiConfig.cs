using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AGDevX.Environments;
using AGDevX.Strings;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AGDevX.Spider.Web.Api.Config
{
    public class ApiConfig
    {
        public EnvironmentType Environment { get; set; } = EnvironmentType.Local;
        public Api Api { get; set; } = new Api();
        public Solution Solution { get; set; } = new Solution();
        public Security Security { get; set; } = new Security();
        public AuthN AuthN { get; set; } = new AuthN();
    }

    public class Api
    {
        public string Author { get; set; } = "AGDevX";
        public string AuthorEmail { get; set; } = "AGDevX@gmail.com";
        public string AuthorUrl { get; set; } = "https://github.com/AGDevX";
        public string Name { get; set; } = "Spider Api";
        public string Description { get; set; } = "RESTful .NET API seed application";
        public string ConnectionString { get; set; } = string.Empty;
        public bool EnableSwagger { get; set; } = true;
    }

    public class Solution
    {
        public string[] AssemblyPrefixes { get; set; } = Array.Empty<string>();
    }

    public class Security
    {
        public string CorsPolicy { get; set; } = "DefaultCorsPolicy";
        public string[] AllowedOrigins { get; set; } = Array.Empty<string>();
        public string[] AllowedMethods { get; set; } = Array.Empty<string>();
        public string[] AllowedHeaders { get; set; } = Array.Empty<string>();
    }

    public class AuthN
    {
        public OAuth OAuth { get; set; } = new OAuth();
    }

    public class OAuth
    {
        public string AuthenticationScheme { get; set; } = JwtBearerDefaults.AuthenticationScheme;

        public string Domain { get; set; } = string.Empty;
        public string Authority { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public bool RequireHttpsMetadata { get; set; } = true;
        public string OpenIDConnectDiscoveryUrl { get; set; } = string.Empty;

        public string _authorizationUrl = string.Empty;
        public string AuthorizationUrl
        {
            get
            {
                if (_authorizationUrl.IsNullOrWhiteSpace())
                {
                    return _authorizationUrl;
                }

                var queryStrings = new List<string>();
                var authZUrl = new StringBuilder(_authorizationUrl);

                if (AuthorizationUrlRequiresAudience)
                {
                    queryStrings.Add($"audience={Audience}");
                }

                if (AuthorizationUrlRequiresNonce)
                {
                    queryStrings.Add($"nonce=${Guid.NewGuid():N}");
                }

                if (queryStrings.Any())
                {
                    authZUrl.Append('?');
                    authZUrl.Append(string.Join('&', queryStrings.ToArray()));
                }

                var authZUrlWithQueryString = authZUrl.ToString();

                return authZUrlWithQueryString;
            }
            set => _authorizationUrl = value;
        }

        public bool AuthorizationUrlRequiresAudience { get; set; } = false;
        public bool AuthorizationUrlRequiresNonce { get; set; } = false;

        public string TokenUrl { get; set; } = string.Empty;
        public string UserInfoUrl { get; set; } = string.Empty;

        public Dictionary<string, string> OidcScopes { get; set; } = new();
        public Dictionary<string, string> ApiScopes { get; set; } = new();

        public Client ApiClient { get; set; } = new Client();
        public Client SpaClient { get; set; } = new Client();
    }

    public class Client
    {
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
    }
}