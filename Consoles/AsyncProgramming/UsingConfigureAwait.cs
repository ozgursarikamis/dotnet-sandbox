namespace AsyncProgramming;

public static class UsingConfigureAwait
{
    public static async Task Run()
    {
        Console.WriteLine("Before awaiting");
        await PerformAsyncTask();
        Console.WriteLine("After awaiting");
    }

    static async Task PerformAsyncTask()
    {
        await Task.Delay(1000).ConfigureAwait(false);
        Console.WriteLine("Task completed");
    }
}