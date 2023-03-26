using System;
using System.Net.Http;
using AGDevX.Web.Auth0.ConfidentialClient.Contracts;
using AGDevX.Web.Auth0.ConfidentialClient.Models;

namespace AGDevX.Web.Auth0.ConfidentialClient;

public class ConfidentialClientFactory : IConfidentialClientFactory
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly Auth0ProviderConfig _auth0ProviderConfig;

    public ConfidentialClientFactory(IHttpClientFactory httpClientFactory, Auth0ProviderConfig auth0ProviderConfig)
    {
        _httpClientFactory = httpClientFactory;
        _auth0ProviderConfig = auth0ProviderConfig;
    }

    public IConfidentialClient CreateClientCredentialsConfidentialClient(string audience)
    {
        var confidentialClientOptions = new ConfidentialClientOptions
        {
            RequestUri = new Uri(_auth0ProviderConfig.OAuth.TokenUrl),
            TokenRequest = new TokenRequest
            {
                client_id = _auth0ProviderConfig.OAuth.ClientId,
                client_secret = _auth0ProviderConfig.OAuth.ClientSecret,
                audience = audience,
                grant_type = "client_credentials",
            }
        };

        var confidentialClient = new ConfidentialClient(_httpClientFactory, confidentialClientOptions);
        return confidentialClient;
    }
}