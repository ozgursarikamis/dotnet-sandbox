namespace CQRS.Kafka.API.Events;

public class BankEvents;

public record MoneyDeposited(Guid AccountId, decimal Amount, DateTime Timestamp);
public record MoneyWithdrawn(Guid AccountId, decimal Amount, DateTime Timestamp);
public record MoneyTransferred(Guid FromAccountId, Guid ToAccountId, decimal Amount, DateTime Timestamp);