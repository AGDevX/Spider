using System.Threading.Tasks;

namespace AGDevX.Web.Auth0.Client.Contracts
{
    public interface IAuth0Client
    {
        public Task<string> GetAccessToken(string audience);
    }
}