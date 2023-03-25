using AGDevX.Web.Auth;
using AGDevX.Web.Auth.AuthN.Oidc;
using AGDevX.Web.Auth.AuthZ.OAuth;
using AGDevX.Web.Auth0;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AGDevX.Web.AuthZ.OAuth;

public static class AddAuth0Extension
{
    public static Auth0ProviderConfig? AddAuth0(this IServiceCollection services, IConfiguration configuration)
    {
        var auth0Config = configuration.GetRequiredSection("ApiConfig:Auth:Auth0").Get<Auth0ProviderConfig>();

        if (auth0Config != null)
        {
            services.AddHttpClient();
            services.AddSingleton<OAuthProviderConfig>(auth0Config.OAuth);
            services.AddSingleton<OidcProviderConfig>(auth0Config.Oidc);
            services.AddSingleton<Auth0ProviderConfig>(auth0Config);
            services.AddSingleton<AuthProviderConfig>(auth0Config);
        }

        return auth0Config;
    }
}