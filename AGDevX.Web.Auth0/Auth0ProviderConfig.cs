using AGDevX.Web.Auth;

namespace AGDevX.Web.Auth0;

public sealed class Auth0ProviderConfig : AuthProviderConfig
{
    public required ManagementApi ManagementApi { get; set; }

}

public sealed class ManagementApi
{
    public required string Audience { get; set; }
}