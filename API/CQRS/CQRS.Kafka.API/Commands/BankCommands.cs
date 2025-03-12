namespace CQRS.Kafka.API.Commands;

public class BankCommands;

public record DepositMoney(Guid AccountId, decimal Amount);
public record WithdrawMoney(Guid AccountId, decimal Amount);
public record TransferMoney(Guid FromAccountId, Guid ToAccountId, decimal Amount);