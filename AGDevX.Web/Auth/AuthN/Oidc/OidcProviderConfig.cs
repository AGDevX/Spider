using System.Collections.Generic;

namespace AGDevX.Web.Auth.AuthN.Oidc;

public class OidcProviderConfig
{
    public required string OpenIDConnectDiscoveryUrl { get; set; }
    public bool RequireHttpsMetadata { get; set; } = true;
    public Dictionary<string, string> Scopes { get; set; } = new();
}