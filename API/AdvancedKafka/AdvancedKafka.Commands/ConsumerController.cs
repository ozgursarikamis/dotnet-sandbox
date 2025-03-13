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
    
    [HttpPost("{topic}")]
    public IActionResult ConsumeMessagesWithTopic(string topic, [FromQuery] string groupId = "group1", [FromQuery] short parallelism = 2)
    {
        Task.Run(() => kafkaConsumer.ConsumeMessage(topic, CancellationToken.None, parallelism));
        return Ok($"Started consuming '{topic}' with group '{groupId}' and parallelism '{parallelism}'");
    }
}