namespace AsyncProgramming;

public static class ExceptionHandlingWithTasks
{
    public static async Task Run()
    {
        var task = PerformAsyncTask().ContinueWith(t =>
        {
            if (t.IsFaulted)
            {
                Console.WriteLine($"Error: {t.Exception?.GetBaseException().Message}");
            }
        });

        await task;
    }

    private static async Task PerformAsyncTask()
    {
        await Task.Delay(2000);
        throw new InvalidOperationException("Something went wrong");
    }
}