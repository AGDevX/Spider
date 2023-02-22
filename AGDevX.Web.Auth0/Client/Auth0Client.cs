using System.Threading.Tasks;
using AGDevX.Web.Auth0.Client.Contracts;
using AGDevX.Web.Auth0.ConfidentialClient.Contracts;

namespace AGDevX.Web.Auth0.Client
{
    public class Auth0Client : IAuth0Client
    {
        protected readonly IConfidentialClientFactory _confidentialClientFactory;

        public Auth0Client(IConfidentialClientFactory confidentialClientFactory)
        {
            _confidentialClientFactory = confidentialClientFactory;
        }

        public async Task<string> GetAccessToken(string audience)
        {
            var application = _confidentialClientFactory.CreateClientCredentialsConfidentialClient(audience);
            var result = await application.AcquireToken();

            return result.access_token;
        }
    }
}