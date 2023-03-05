using System.Threading.Tasks;
using AGDevX.Web.Auth0.ConfidentialClient.Models;

namespace AGDevX.Web.Auth0.ConfidentialClient.Contracts;

public interface IConfidentialClient
{
    Task<TokenResponse> AcquireToken();
}