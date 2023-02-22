namespace AGDevX.Web.Auth0.ConfidentialClient.Contracts
{
    public interface IConfidentialClientFactory
    {
        /// <summary>
        /// Creates a confidential client to request an access token via client credentials for making machine to machine calls
        /// </summary>
        /// <param name="audience">Identifier of the API that will be called</param>
        /// <returns>Confidential client</returns>
        IConfidentialClient CreateClientCredentialsConfidentialClient(string audience);
    }
}