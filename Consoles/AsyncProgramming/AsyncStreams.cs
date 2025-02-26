namespace AsyncProgramming;

public static class AsyncStreams
{
    public static async Task Run()
    {
        // await EnumerateAsyncStream();
        await ReadLargeTextFileUsingAsyncStream();
    }

    private static async Task ReadLargeTextFileUsingAsyncStream()
    {
        const string url = "https://raw.githubusercontent.com/dscape/spell/refs/heads/master/test/resources/big.txt";
        await foreach (var line in ReadFileLinesAsync(url))
        {
            Console.WriteLine(line);
            Console.WriteLine("==== end of the chunk ====");
        }
    }

    private static async IAsyncEnumerable<string> ReadFileLinesAsync(string url)
    {
        using var client = new HttpClient();
        await using var stream = await client.GetStreamAsync(url);
        using var streamReader = new StreamReader(stream);

        while (await streamReader.ReadLineAsync() is { } line)
            yield return line; // yield each line asynchronously.
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

    private static async IAsyncEnumerable<string> FetchItemsAsync()
    {
        string[] pages = { "Page1", "Page2", "Page3", "Page4", "Page5", "Page6", "Page7" };
        foreach (var page in pages)
        {
            // simulate the delay for fetching each page (e.g. network call)
            await Task.Delay(1000);
            yield return page;
        }
    }
}