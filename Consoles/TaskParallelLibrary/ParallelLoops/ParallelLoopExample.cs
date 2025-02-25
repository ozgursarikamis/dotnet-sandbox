namespace TaskParallelLibrary.ParallelLoops;

public static class ParallelLoopExample
{
    public static void Run()
    {
        // Parallel.For(0, 10, i =>
        // {
        //     Console.WriteLine($"For: {i}");
        //     Task.Delay(500).Wait();
        // });
        
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Parallel.ForEach(numbers, number =>
        {
            Console.WriteLine($"Processing {number} on thread {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            // Simulate some work
            Task.Delay(500).Wait();
        });
        Console.WriteLine("Parallel.ForEach() completed");
        Console.ReadKey();
    }
}