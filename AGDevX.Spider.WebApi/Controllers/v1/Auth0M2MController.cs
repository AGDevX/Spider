using System.Threading.Tasks;
using AGDevX.Spider.WebApi.Config;
using AGDevX.Web.Auth.AuthZ.Attributes;
using AGDevX.Web.Auth0;
using AGDevX.Web.Auth0.Client.Contracts;
using AGDevX.Web.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.WebApi.Controllers.v1;

/// <summary>
/// For demonstration purposes only. Do not expose in production the functionality that this controller does.
/// </summary>
[ApiController]
[Route("v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[AuthorizedScopes(AuthorizedScopes.Any)]
[AuthorizedRoles(AuthorizedRoles.Any)]
public sealed class Auth0M2MController : ControllerBase
{
    private readonly ILogger<Auth0M2MController> _logger;
    private readonly Auth0ProviderConfig _apiConfig;
    private readonly IAuth0Client _auth0Client;

    public Auth0M2MController(
        ILogger<Auth0M2MController> logger,
        Auth0ProviderConfig apiConfig,
        IAuth0Client auth0Client)
    {
        _logger = logger;
        _apiConfig = apiConfig;
        _auth0Client = auth0Client;
    }

    /// <summary>
    /// Returns an access token in the context of this API for a downstream API (never expose an endpoint like this)
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        //-- This call typically wouldn't be made in a controller. It would be made in a class that needs to
        //--    make a call to a downstream api so it can send an access token to that API
        var accessToken = await _auth0Client.GetAccessToken(_apiConfig.Auth0ManagementApi.Audience);

        return new OkResponse<string>
        {
            Value = accessToken
        };
    }
}