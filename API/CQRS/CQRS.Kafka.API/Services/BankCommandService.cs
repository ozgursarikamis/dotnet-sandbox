using CQRS.Kafka.API.Commands;
using CQRS.Kafka.API.Events;

namespace CQRS.Kafka.API.Services;

public class BankCommandService(KafkaProducerService kafkaProducer)
{
    private const string TOPIC_NAME = "bank-events";
    public async Task HandleDeposit(DepositMoney command)
    {
        var evt = new MoneyDeposited(command.AccountId, command.Amount, DateTime.UtcNow);
        await kafkaProducer.PublishEventAsync(TOPIC_NAME, evt);
    }

    public async Task HandleWithdraw(WithdrawMoney command)
    {
        var evt = new MoneyWithdrawn(command.AccountId, command.Amount, DateTime.UtcNow);
        await kafkaProducer.PublishEventAsync(TOPIC_NAME, evt);
    }

    public async Task HandleTransfer(TransferMoney command)
    {
        var evt = new MoneyTransferred(command.FromAccountId, command.ToAccountId, command.Amount, DateTime.UtcNow);
        await kafkaProducer.PublishEventAsync(TOPIC_NAME, evt);
    }
}
