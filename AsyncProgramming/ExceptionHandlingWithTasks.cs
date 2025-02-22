namespace AsyncProgramming;

public static class ExceptionHandlingWithTasks
{
    public static async Task Run()
    {
        try
        {
            await PerformAsyncTask();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught Exception: {ex.Message}");
        }
    }

    private static async Task PerformAsyncTask()
    {
        await Task.Delay(2000);
        throw new InvalidOperationException("Something went wrong");
    }
}