namespace Events_Delegates_Action_Func;

public class ActionsAsParameter
{
    public static void Run()
    {
        var processor = new OrderProcessor();
        
        // Log:
        Action<string> consoleLogger = message => Console.WriteLine($"[LOG]: {message}");
        processor.ProcessOrder("Pizza", consoleLogger);
    }
}

public class OrderProcessor
{
    public void ProcessOrder(string order, Action<string> logAction)
    {
        logAction("Processing order: " + order);
        Console.WriteLine($"Order processed: {order}");
    }
}