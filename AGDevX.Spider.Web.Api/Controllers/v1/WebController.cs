using AGDevX.Spider.Web.Api.Config;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.Web.Api.Controllers.v1
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class WebController : ControllerBase
    {
        private readonly ILogger<SpiderController> _logger;
        private readonly ApiConfig _apiConfig;

        public WebController(ILogger<SpiderController> logger, ApiConfig apiConfig)
        {
            _logger = logger;
            _apiConfig = apiConfig;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_apiConfig);
        }
    }
}