using Microsoft.AspNetCore.Mvc;

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