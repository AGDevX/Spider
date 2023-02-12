using AGDevX.Spider.WebApi.Config;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.WebApi.Controllers.v1
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public sealed class WebController : ControllerBase
    {
        private readonly ILogger<SpiderController> _logger;
        private readonly ApiConfig _apiConfig;

        public WebController(ILogger<SpiderController> logger, ApiConfig apiConfig)
        {
            _logger = logger;
            _apiConfig = apiConfig;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Get()
        {
            var user = User;

            return new OkObjectResult(_apiConfig);
        }
    }
}