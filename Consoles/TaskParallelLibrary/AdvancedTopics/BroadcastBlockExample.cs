using System.Threading.Tasks.Dataflow;

namespace TaskParallelLibrary.AdvancedTopics;

public static class BroadcastBlockExample
{
    public static async Task Run()
    {
        // BroadcastBlock to distribute sensor data:
        var sensorDataBroadcaster = new BroadcastBlock<int>(null);
        
        // ActionBlock to process sensor data (algorithm 1):
        var algorithm1 = new ActionBlock<int>(async data =>
        {
            await Task.Delay(500);
            Console.WriteLine($"Algorithm 1: Processed {data}");
        });
        
        // ActionBlock to process sensor data (algorithm 2):
        var algorithm2 = new ActionBlock<int>(async data =>
        {
            await Task.Delay(500);
            Console.WriteLine($"Algorithm 2: Processed {data}");
        });
        
        // Link the broadcaster to the algorithms:
        sensorDataBroadcaster.LinkTo(algorithm1);
        sensorDataBroadcaster.LinkTo(algorithm2);
        
        // Simulate sensor data input:
        for (var i = 0; i < 100; i++)
            sensorDataBroadcaster.Post(i);

        // or if the order doesn't matter:
        // Parallel.For(0, 100, i =>
        // {
        //     sensorDataBroadcaster.Post(i);
        // });
        
        // Signal completion:
        sensorDataBroadcaster.Complete();
        // wait for the processor to finish:
        await Task.WhenAll(algorithm1.Completion, algorithm2.Completion);

        Console.WriteLine("Sensor data processing complete");
        Console.ReadKey();
    }
}