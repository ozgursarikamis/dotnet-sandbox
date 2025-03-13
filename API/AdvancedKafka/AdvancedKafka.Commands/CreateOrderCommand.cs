using AdvancedKafka.SharedKernel;

namespace AdvancedKafka.Commands;

public class CreateOrderCommand : CommandBase
{
    public string OrderId { get; set; }
    public string CustomerName { get; set; }
    public decimal Amount { get; set; }
}

public class CreateCustomerCommand : CommandBase
{
    public string CustomerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}