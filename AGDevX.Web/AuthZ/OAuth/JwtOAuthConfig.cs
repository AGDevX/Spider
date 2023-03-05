using System.Security.Claims;
using AGDevX.Enums;
using AGDevX.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AGDevX.Web.AuthZ.OAuth;

public sealed class JwtOAuthConfig
{
    public string AuthenticationScheme { get; set; } = JwtBearerDefaults.AuthenticationScheme;
    public string NameClaimType { get; set; } = ClaimTypes.NameIdentifier;
    public string RoleClaimType { get; set; } = JwtClaimType.Roles.StringValue();
    public required string Authority { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public required bool RequireHttpsMetadata { get; set; } = true;
    public required string OpenIDConnectDiscoveryUrl { get; set; }
}