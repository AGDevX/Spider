using System.Collections.Generic;

namespace AGDevX.Web.AuthN.Oidc;

public sealed class OidcProviderConfig
{
    public string OpenIDConnectDiscoveryUrl { get; set; } = string.Empty;
    public bool RequireHttpsMetadata { get; set; } = true;
    public Dictionary<string, string> Scopes { get; set; } = new();
}