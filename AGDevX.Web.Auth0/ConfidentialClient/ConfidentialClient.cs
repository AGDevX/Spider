using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AGDevX.Exceptions;
using AGDevX.Web.Auth0.ConfidentialClient.Contracts;
using AGDevX.Web.Auth0.ConfidentialClient.Models;
using Newtonsoft.Json;

//-- https://oauth.net/2/client-types
//-- https://auth0.com/docs/get-started/applications/confidential-and-public-applications

namespace AGDevX.Web.Auth0.ConfidentialClient;

public class ConfidentialClient : IConfidentialClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ConfidentialClientOptions _confidentialClientOptions;

    public ConfidentialClient(IHttpClientFactory httpClientFactory, ConfidentialClientOptions confidentialClientOptions)
    {
        _httpClientFactory = httpClientFactory;
        _confidentialClientOptions = confidentialClientOptions;
    }

    public async Task<TokenResponse> AcquireToken()
    {
        var httpClient = GetHttpClient();

        var serializedTokenRequest = JsonConvert.SerializeObject(_confidentialClientOptions.TokenRequest);
        var authCodeRequestMessage = new HttpRequestMessage
        {
            RequestUri = _confidentialClientOptions.RequestUri,
            Method = HttpMethod.Post,
            Content = new StringContent(serializedTokenRequest, Encoding.UTF8, "application/json")
        };

        var response = await httpClient.SendAsync(authCodeRequestMessage, HttpCompletionOption.ResponseHeadersRead);

        using (var stream = await response.Content.ReadAsStreamAsync())
        using (var streamReader = new StreamReader(stream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var tokenResponse = new JsonSerializer().Deserialize<TokenResponse>(jsonTextReader)
                                    ?? throw new AcquireTokenException("Unable to acquire an access token from Auth0");
            return tokenResponse;
        }
    }

    private HttpClient GetHttpClient()
    {
        var httpClient = _httpClientFactory.CreateClient();

        var mediaTypeHeader = new MediaTypeWithQualityHeaderValue("application/json");

        httpClient.DefaultRequestHeaders.Accept.Add(mediaTypeHeader);

        return httpClient;
    }
}