namespace AdvancedKafka.Shared.Config;

public class KafkaSettings
{
    public string BootstrapServers { get; set; } = string.Empty;
    public string OrderTopic { get; set; } = "orders";
    public string CustomerTopic { get; set; } = "customers";
}