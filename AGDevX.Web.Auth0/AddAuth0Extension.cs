using Microsoft.Extensions.DependencyInjection;

namespace AGDevX.Web.AuthZ.OAuth;

public static class AddAuth0Extension
{
    public static IServiceCollection AddAuth0(this IServiceCollection services, OAuthProviderConfig oAuthProviderConfig)
    {
        //-- HTTP Client Factory
        services.AddHttpClient();
        services.AddSingleton<OAuthProviderConfig>(oAuthProviderConfig);

        return services;
    }
}