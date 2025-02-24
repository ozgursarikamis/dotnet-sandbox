namespace AsyncProgramming;

public static class CancelAnAsyncTask
{
    public static async Task Run()
    {
        // Create the CancellationTokenSource
        var cts = new CancellationTokenSource();

        // Start the task and pass the token
        var cancellationToken = cts.Token;
        var fetchDataTask = FetchDataAsync(cancellationToken);

        // Simulate a user requesting cancellation after 3 seconds
        await Task.Delay(3000, cancellationToken); // Wait for 3 seconds
        Console.WriteLine("Cancelling task...");
        await cts.CancelAsync(); // Trigger the cancellation

        try
        {
            // Wait for the task to complete
            await fetchDataTask;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Task was cancelled.");
        }
    }

    private static async Task FetchDataAsync(CancellationToken cancellationToken)
    {
        for (var i = 0; i < 10; i++)
        {
            // check if cancellation has been requested:
            cancellationToken.ThrowIfCancellationRequested();
            
            // simulate the work:
            await Task.Delay(1000, cancellationToken);
            Console.WriteLine($"Fetching data...{i + 1}/ 10");
        }

        Console.WriteLine("Data fetched successfully");
    }
}