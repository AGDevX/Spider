using System.Threading.Tasks;
using AGDevX.Spider.Web.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.Web.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class SpiderController : ControllerBase
    {
        private readonly ILogger<SpiderController> _logger;
        private readonly ApiConfig _apiConfig;

        public SpiderController(ILogger<SpiderController> logger, ApiConfig apiConfig)
        {
            _logger = logger;
            _apiConfig = apiConfig;
        }

        [HttpGet(Name = "GetSpider")]
        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(_apiConfig);
        }
    }
}