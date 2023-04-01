using AGDevX.Web.Auth0;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AGDevX.Web.AuthZ.OAuth;

public static class AddAuth0Extension
{
    public static void ConfigureAuth0(this IServiceCollection services, IConfiguration configuration, Auth0ProviderConfig auth0Config)
    {
        services.AddHttpClient();
        services.AddSingleton<Auth0ProviderConfig>(auth0Config);
    }
}