using System.Threading.Tasks;
using AGDevX.Spider.WebApi.Config;
using AGDevX.Web.Auth0.Client.Contracts;
using AGDevX.Web.AuthZ.Attributes;
using AGDevX.Web.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.WebApi.Controllers.v1
{
    /// <summary>
    /// For demonstration purposes only. Do not expose in production the functionality that this controller does.
    /// </summary>
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public sealed class Auth0M2MController : ControllerBase
    {
        private readonly ILogger<Auth0M2MController> _logger;
        private readonly ApiConfig _apiConfig;
        private readonly IAuth0Client _auth0Client;

        public Auth0M2MController(
            ILogger<Auth0M2MController> logger,
            ApiConfig apiConfig,
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
        [AuthorizedScopes(AuthorizedScopes.Any)]
        [AuthorizedRoles(AuthorizedRoles.Any)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            //-- This call typically wouldn't be made in a controller. It would be made in a class that needs to
            //--    make a call to a downstream api so it can send an access token to that API
            var accessToken = await _auth0Client.GetAccessToken(_apiConfig.Auth.OAuth.Audience);

            return new OkJsonResponse<string>
            {
                Code = ApiResponseCodes.Success,
                Value = accessToken
            };
        }
    }
}