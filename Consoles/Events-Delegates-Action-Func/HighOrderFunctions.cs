namespace Events_Delegates_Action_Func;
// A higher-order function is a function that:
//
// Accepts another function as an argument (Action<T> or Func<T>)
// Returns a function as its result
public static class HighOrderFunctions
{
    public static void Run()
    {
        MeasureExecutionTime(TaskToMeasure);
    }
    
    static void MeasureExecutionTime(Action action)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        action();
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
    }

    static void TaskToMeasure()
    {
        Console.WriteLine("📊 Simulating a task...");
        Thread.Sleep(3000); // Simulate a 300ms task
    }
}