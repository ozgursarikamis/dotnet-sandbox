using Microsoft.AspNetCore.Mvc;

namespace AdvancedKafka.Commands
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        // GET: api/test
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from Kafka Controller!");
        }
    }
}