using System.Threading.Tasks;
using AGDevX.Spider.WebApi.AuthZ;
using AGDevX.Spider.WebApi.Config;
using AGDevX.Web.Auth0.Client.Contracts;
using AGDevX.Web.AuthZ.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.WebApi.Controllers.v1
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public sealed class SpiderController : ControllerBase
    {
        private readonly ILogger<SpiderController> _logger;
        private readonly ApiConfig _apiConfig;
        private readonly IAuth0Client _auth0Client;

        public SpiderController(
            ILogger<SpiderController> logger,
            ApiConfig apiConfig,
            IAuth0Client auth0Client)
        {
            _logger = logger;
            _apiConfig = apiConfig;
            _auth0Client = auth0Client;
        }

        [HttpGet]
        [LogAuthorize(Roles.AGDevXAdmin, Roles.Admin, Roles.Normal)]
        public async Task<IActionResult> Get()
        {
            //-- This call typically wouldn't be made in a controller. It would be made in a class that needs to
            //--    make a call to a downstream api so it can send an access token to that API
            var at = await _auth0Client.GetAccessToken(_apiConfig.Auth.OAuth.Audience);

            return new OkObjectResult(_apiConfig);
        }
    }
}