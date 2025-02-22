namespace AsyncProgramming;

public static class AsyncStreams
{
    public static async Task Run()
    {
        await EnumerateAsyncStream();
    }

    private static async Task EnumerateAsyncStream()
    {
        await foreach (var number in GetNumberAsync())
        {
            Console.WriteLine(number);
        }
    }

    private static async IAsyncEnumerable<int> GetNumberAsync()
    {
        for (var i = 0; i < 10; i++)
        {
            await Task.Delay(500);  // Simulate asynchronous work (e.g., fetching from DB)
            yield return i;         // Yield each item asynchronously
        }
    }
}