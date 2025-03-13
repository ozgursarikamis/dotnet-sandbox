using AdvancedKafka.Shared.Config;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedKafka.Commands
{
    [ApiController, Route("api/[controller]")]
    public class ProducerController(KafkaProducer producer, ILogger<KafkaProducer> logger): ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Hello from Kafka Controller!");

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] string message, [FromQuery] string topic)
        {
            try
            {
                var deliveryResult = await producer.ProduceMessageAsync(message, topic);
                logger.LogInformation($"Message produced: {deliveryResult.Value}");
                return Ok(deliveryResult.Value);
            }
            catch (ProduceException<Null, string> ex)
            {
                logger.LogError($"Error producing message: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}