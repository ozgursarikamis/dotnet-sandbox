using System.Threading.Tasks.Dataflow;

namespace TaskParallelLibrary.AdvancedTopics;

public static class JoinBlockExample
{
    public static async Task Run()
    {
        // JoinBlock to combine Customer and Order data
        var joinBlock = new JoinBlock<Customer, Order, int>(new GroupingDataflowBlockOptions());

        // ActionBlock to process CustomerOrder objects
        var processor = new ActionBlock<Tuple<Customer, Order, int>>(tuple =>
        {
            var customer = tuple.Item1;
            var order = tuple.Item2;
            var num = tuple.Item3;
            Console.WriteLine($"{num}| Customer: {customer.Name}, Order: {order.Product}");
        });

        // Link the JoinBlock to the processor
        joinBlock.LinkTo(processor);

        // Simulate Customer data input
        var customers = new[]
        {
            new Customer { CustomerId = 1, Name = "Alice" },
            new Customer { CustomerId = 2, Name = "Bob" },
        };

        // Simulate Order data input
        var orders = new[]
        {
            new Order { CustomerId = 1, OrderId = 101, Product = "Laptop" },
            new Order { CustomerId = 2, OrderId = 102, Product = "Phone" },
        };

        foreach (var customer in customers)
            joinBlock.Target1.Post(customer);

        foreach (var order in orders)
            joinBlock.Target2.Post(order);

        for (var i = 0; i < customers.Length; i++)
            joinBlock.Target3.Post(new Random().Next(0, 100));

        // Signal completion
        joinBlock.Complete();
        await processor.Completion; // waits for the ActionBlock to finish processing all combined data items.

        Console.WriteLine("Customer order aggregation complete.");
        Console.ReadKey();
    }
}

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
}

public class Order
{
    public int CustomerId { get; set; }
    public int OrderId { get; set; }
    public string Product { get; set; }
}

public class CustomerOrder
{
    public Customer Customer { get; set; }
    public Order Order { get; set; }
}