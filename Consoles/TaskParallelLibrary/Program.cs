using TaskParallelLibrary;
using TaskParallelLibrary.AdvancedTopics;
using TaskParallelLibrary.Basics;
using TaskParallelLibrary.ParallelLoops;
using TaskParallelLibrary.Multithreading;

// TaskBasics.Run();
// ParallelLoopExample.Run();
// ThreadSafeCollections.Run();
// await BufferBlockExample.Run();
// await TransformBlockExample.Run();
// await ActionBlockExample.Run();
// await BroadcastBlockExample.Run();
// await JoinBlockExample.Run();

// var counter = new RequestCounter();
var counter = new MonitorExample();

// Simulate multiple requests from different threads:
await Task.WhenAll(
    Task.Run(() => { for (int i = 0; i < 1000; i++) { counter.IncrementCounter(); } }),
    Task.Run(() => { for (int i = 0; i < 1000; i++) { counter.IncrementCounter(); } }),
    Task.Run(() => { for (int i = 0; i < 1000; i++) { counter.IncrementCounter(); } })
);

Console.WriteLine($"Total requests: {counter.GetCount()}");
Console.ReadKey();