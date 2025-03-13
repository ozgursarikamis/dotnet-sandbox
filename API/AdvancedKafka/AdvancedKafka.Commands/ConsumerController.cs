using AdvancedKafka.Shared.Config;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedKafka.Commands;

[ApiController, Route("api/[controller]")]
public class ConsumerController(KafkaConsumer kafkaConsumer) : ControllerBase
{
    [HttpGet("consume")]
    public IActionResult ConsumeMessages([FromQuery] string topic)
    {
        if (string.IsNullOrEmpty(topic))
            return BadRequest("Topic is required.");

        Task.Run(() => kafkaConsumer.ConsumeMessage(topic, CancellationToken.None));
        return Ok($"Started consuming messages from {topic}.");
    }
}