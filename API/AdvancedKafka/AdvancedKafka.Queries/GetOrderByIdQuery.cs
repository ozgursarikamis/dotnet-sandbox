using AdvancedKafka.SharedKernel;

namespace AdvancedKafka.Queries;

public class GetOrderByIdQuery : QueryBase
{
    public string OrderId { get; set; }
}

public class GetCustomerByIdQuery : QueryBase
{
    public string CustomerId { get; set; }
}