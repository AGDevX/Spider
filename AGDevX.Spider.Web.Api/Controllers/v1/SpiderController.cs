using System.Threading.Tasks;
using AGDevX.Spider.Web.Api.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.Web.Api.Controllers.v1
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class SpiderController : ControllerBase
    {
        private readonly ILogger<SpiderController> _logger;
        private readonly ApiConfig _apiConfig;

        public SpiderController(ILogger<SpiderController> logger, ApiConfig apiConfig)
        {
            _logger = logger;
            _apiConfig = apiConfig;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(_apiConfig);
        }
    }
}