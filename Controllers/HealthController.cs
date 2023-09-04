using Microsoft.AspNetCore.Mvc;

namespace SimpleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;

        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult Check()
        {
            _logger.LogInformation($"����� {nameof(Check)} ��� ������");

            return Ok();
        }
    }
}