using System;
using System.Net.Http;
using AGDevX.Web.Auth0.ConfidentialClient.Contracts;
using AGDevX.Web.Auth0.ConfidentialClient.Models;
using AGDevX.Web.AuthZ.OAuth;

namespace AGDevX.Web.Auth0.ConfidentialClient;

public class ConfidentialClientFactory : IConfidentialClientFactory
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly OAuthProviderConfig _oAuthProviderConfig;

    public ConfidentialClientFactory(IHttpClientFactory httpClientFactory, OAuthProviderConfig oAuthProviderConfig)
    {
        _httpClientFactory = httpClientFactory;
        _oAuthProviderConfig = oAuthProviderConfig;
    }

    public IConfidentialClient CreateClientCredentialsConfidentialClient(string audience)
    {
        var confidentialClientOptions = new ConfidentialClientOptions
        {
            RequestUri = new Uri(_oAuthProviderConfig.TokenUrl),
            TokenRequest = new TokenRequest
            {
                client_id = _oAuthProviderConfig.ApiClient.ClientId,
                client_secret = _oAuthProviderConfig.ApiClient.ClientSecret,
                audience = audience,
                grant_type = "client_credentials",
            }
        };

        var confidentialClient = new ConfidentialClient(_httpClientFactory, confidentialClientOptions);
        return confidentialClient;
    }
}