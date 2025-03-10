namespace CQRS.Kafka.API.Entities;

public class Transaction
{
    public int Id { get; set; }
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Timestamp { get; set; }
}