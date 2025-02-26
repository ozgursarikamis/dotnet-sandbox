using System.Threading.Tasks.Dataflow;

namespace TaskParallelLibrary.AdvancedTopics;

public static class BufferBlockExample
{
    public static async Task Run()
    {
        // BufferBlock to store incoming log messages:
        var logBuffer = new BufferBlock<string>();
        
        // ActionBlock to process log messages:
        var logProcessor = new ActionBlock<string>(async log =>
        {
            await Task.Delay(500);
            Console.WriteLine($"Processing log: {log}");
        });
        
        // Link the BufferBlock to the ActionBlock:
        logBuffer.LinkTo(logProcessor);
        
        // Stimulate the log messages generation:
        for (int i = 0; i < 100; i++)
        {
            string logMessage = $"Log message {i} at {DateTime.Now}";
            logBuffer.Post(logMessage);
            
            // Simulate log generation interval:
            await Task.Delay(100);
        }
        
        // Signal that no more logs are coming:
        logBuffer.Complete();
        
        // Wait for the processor to finish:
        await logBuffer.Completion;

        Console.WriteLine("Log processing complete.");
        Console.ReadKey();
    }
}