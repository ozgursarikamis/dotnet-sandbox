namespace TaskParallelLibrary.Multithreading;

public static class ResourcePool
{
    public static async Task Run()
    {
        Smphr = new Semaphore(MaxResources, MaxResources);
        
        // Simulate multiple threads accessing the resource:

        var tasks = new List<Task>
        {
            Task.Run(AccessResource),
            Task.Run(AccessResource),
            Task.Run(AccessResource),
            Task.Run(AccessResource),
            Task.Run(AccessResource)
        };
        await Task.WhenAll(tasks);

        Console.WriteLine("Resource access complete.");
        Console.ReadKey();
    }

    private static Semaphore? Smphr { get; set; }
    private const int MaxResources = 3;

    private static async Task AccessResource()
    {
        var threadId = Environment.CurrentManagedThreadId;
        Console.WriteLine($"Thread {threadId} attempting to access resource.");
        Smphr?.WaitOne(); // Acquire a semaphore slot

        Console.WriteLine($"Thread {threadId} acquired resource. Accessing...");
        
        // Simulate accessing the resource:
        await Task.Delay(2000);

        Console.WriteLine($"Thread {threadId} releasing resource...");
        Smphr?.Release();
    }
}