using System.Collections.Concurrent;

namespace TaskParallelLibrary.ParallelLoops;

public static class ThreadSafeCollections
{
    public static void Run()
    {
        ConcurrentBag<int> results = new ConcurrentBag<int>();
        Parallel.For(1, 11, x =>
        {
            results.Add(x * x);
        });

        foreach (var item in results)
        {
            Console.WriteLine($"Item in result: {item}");
        }

        Console.ReadKey();
    }
}