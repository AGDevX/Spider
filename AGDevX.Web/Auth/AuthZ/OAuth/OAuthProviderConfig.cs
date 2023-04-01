using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AGDevX.Enums;
using AGDevX.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AGDevX.Web.Auth.AuthZ.OAuth;

public class OAuthProviderConfig
{
    public string AuthenticationScheme { get; set; } = JwtBearerDefaults.AuthenticationScheme;
    public string NameClaimType { get; set; } = ClaimTypes.NameIdentifier;
    public string RoleClaimType { get; set; } = JwtClaimType.Roles.StringValue();

    public required string Domain { get; set; }
    public required string Authority { get; set; }
    public required string Issuer { get; set; }

    public required string Audience { get; set; }
    public required string ClientId { get; set; }
    public required string ClientSecret { get; set; }

    public string _authorizationUrl = string.Empty;
    public required string AuthorizationUrl
    {
        get
        {
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

    public bool AuthorizationUrlRequiresAudience { get; set; }
    public bool AuthorizationUrlRequiresNonce { get; set; }

    public required string TokenUrl { get; set; }
    public required string UserInfoUrl { get; set; }
    public required string JsonWebKeySetUrl { get; set; }

    public Dictionary<string, string> ApiScopes { get; set; } = new();
}