using AGDevX.Web.Auth.AuthN.Oidc;
using AGDevX.Web.Auth.AuthZ.OAuth;

namespace AGDevX.Web.Auth;

public class AuthProviderConfig
{
    public required OAuthProviderConfig OAuth { get; set; }
    public required OidcProviderConfig Oidc { get; set; }
}