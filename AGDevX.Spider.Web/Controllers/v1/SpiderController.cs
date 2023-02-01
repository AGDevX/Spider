using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.Web.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class SpiderController : ControllerBase
    {
        private readonly ILogger<SpiderController> _logger;

        public SpiderController(ILogger<SpiderController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSpider")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}