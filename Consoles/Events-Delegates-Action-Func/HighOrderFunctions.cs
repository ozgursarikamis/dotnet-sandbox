namespace Events_Delegates_Action_Func;
// A higher-order function is a function that:
//
// Accepts another function as an argument (Action<T> or Func<T>)
// Returns a function as its result
public static class HighOrderFunctions
{
    public static void Run()
    {
        // MeasureExecutionTime(TaskToMeasure);
        // FuncAsParameter();
        ReturningAFunction();
    }

    private static void ReturningAFunction()
    {
        double distance = 150;
        Console.WriteLine($"Travel Method: {GetTravelMethod(distance)()}");
        return;

        static Func<string> GetTravelMethod(double distance)
        {
            if (distance < 2)
                return () => "Walking";
            if (distance < 100)
                return () => "Driving";
            return () => "Flying";
        }
    }

    private static void FuncAsParameter()
    {
        double originalPrice = 100.0;
        
        // Different discount functions:
        Func<double, double> regularDiscount = price => price * 0.9;
        Func<double, double> premiumDiscount = price => price * 0.80;
        Func<double, double> noDiscount = price => price;

        Console.WriteLine($"Original Price: {originalPrice}");
        Console.WriteLine($"Regular Discount: {ApplyDiscount(originalPrice, regularDiscount)}");
        Console.WriteLine($"Premium Discount: {ApplyDiscount(originalPrice, premiumDiscount)}");
        Console.WriteLine($"No Discount: {ApplyDiscount(originalPrice, noDiscount)}");
    }

    private static void MeasureExecutionTime(Action action)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        action();
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
    }

    private static void TaskToMeasure()
    {
        Console.WriteLine("📊 Simulating a task...");
        Thread.Sleep(3000); // Simulate a 300ms task
    }

    private static double ApplyDiscount(double price, Func<double, double> discountFunc)
    {
        return discountFunc(price);
    }
}