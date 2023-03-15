using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AGDevX.Enums;
using AGDevX.Security;
using AGDevX.Strings;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AGDevX.Web.AuthZ.OAuth;

public sealed class OAuthProviderConfig
{
    public string AuthenticationScheme { get; set; } = JwtBearerDefaults.AuthenticationScheme;
    public string NameClaimType { get; set; } = ClaimTypes.NameIdentifier;
    public string RoleClaimType { get; set; } = JwtClaimType.Roles.StringValue();

    public string Domain { get; set; } = string.Empty;
    public string Authority { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;

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
    public string JsonWebKeySetUrl { get; set; } = string.Empty;

    public Dictionary<string, string> ApiScopes { get; set; } = new();

    public Client ApiClient { get; set; } = new Client();
}

public sealed class Client
{
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
}