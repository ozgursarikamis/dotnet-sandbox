namespace AsyncProgramming;

public static class TaskProgress
{
    public static async Task Run()
    {
        // await UsingIProgress();
        await DownloadLargeFileWithProgress();
    }
    
    #region DownloadLargeFileWithProgress
    private static async Task DownloadLargeFileWithProgress()
    {
        const string fileUrl = "https://link.testfile.org/PDF100MB";
        const string destinationPath = "pdf-10-bin.pdf";
        var progress = new Progress<int>(percentage =>
        {
            Console.WriteLine($"Download progress: {percentage}%");
        });
        
        await DownloadFileAsync(fileUrl, destinationPath, progress);
    }

    private static async Task DownloadFileAsync(string fileUrl, string destinationPath, IProgress<int> progress)
    {
        using var client = new HttpClient();
        using var response = await client.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();
        
        var totalBytes = response.Content.Headers.ContentLength ?? 0;
        var downloadedBytes = 0L;

        await using var fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None);
        await using var stream = await response.Content.ReadAsStreamAsync();
        var buffer = new byte[8192]; // 8 KB buffer
        int bytesRead;
        while ((bytesRead = await stream.ReadAsync(buffer)) > 0)
        {
            await fileStream.WriteAsync(buffer.AsMemory(0, bytesRead));
            downloadedBytes += bytesRead;

            // Calculate percentage progress
            var progressPercentage = (int)((downloadedBytes * 100) / totalBytes);
                    
            // Report progress
            progress.Report(progressPercentage);
        }
    }

    #endregion

    #region Basics

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
    #endregion
}