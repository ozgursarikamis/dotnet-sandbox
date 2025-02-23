namespace AsyncProgramming;

public static class TaskProgress
{
    public static async Task Run()
    {
        await UsingIProgress();
    }

    private static async Task UsingIProgress()
    {
        await DownloadAsync("https://www.google.com", TrackProgress());
    }

    private static Progress<int> TrackProgress()
    {
        return new Progress<int>(percentage => Console.WriteLine($"Progress: {percentage}"));
    }

    private static async Task DownloadAsync(string fileUrl, IProgress<int> progress)
    {
        // simulate a large file download:
        for (var i = 0; i < 100; i++)
        {
            await Task.Delay(100);
            
            // Report progress:
            progress.Report(i);
        }
    }
}