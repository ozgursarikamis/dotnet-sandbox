namespace Events_Delegates_Action_Func;

public static class CustomDelegates
{
    public static void Run()
    {
        CalculateTotal totalPrice = ComputeTotal;
        Console.WriteLine($"Total: {totalPrice(10.99m, 0.08m)}");
    }

    private static decimal ComputeTotal(decimal price, decimal taxRate)
    {
        return price + price * taxRate;
    }
}

delegate decimal CalculateTotal(decimal price, decimal taxRate);