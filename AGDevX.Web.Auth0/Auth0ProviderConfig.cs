using AGDevX.Web.Auth;

namespace AGDevX.Web.Auth0;

public sealed class Auth0ProviderConfig : AuthProviderConfig
{
    public required Auth0ManagementApi Auth0ManagementApi { get; set; }

}

public sealed class Auth0ManagementApi
{
    public required string Audience { get; set; }
}