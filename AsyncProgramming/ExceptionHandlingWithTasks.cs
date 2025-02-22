namespace AsyncProgramming;

public static class ExceptionHandlingWithTasks
{
    public static async Task Run()
    {
        // await CatchExceptionWith_ContinueWith();
        await CatchExceptionWith_TaskWhenAll();
    }

    private static async Task CatchExceptionWith_TaskWhenAll()
    {
        var tasks = new[] { Task1(), Task2() };
        try
        {
            await Task.WhenAll(tasks);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Caught exception: {e.Message}");
        }

        Console.WriteLine("All tasks completed");
        Console.WriteLine();
        foreach (var task in tasks)
        {
            if (!task.IsFaulted) continue;
            Console.WriteLine($"Task {task.Id} failed. Exception: {task.Exception?.Message}");
            Console.WriteLine($"{task.Exception?.GetBaseException().Message}");
        }
    }
    
    private static async Task CatchExceptionWith_ContinueWith()
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

    static async Task Task1()
    {
        await Task.Delay(1000);
        Console.WriteLine("Task1 completed.");
        throw new InvalidOperationException("Task1 failed!");
    }

    static async Task Task2()
    {
        await Task.Delay(2000);
        Console.WriteLine("Task2 completed.");
        throw new ArgumentException("Task2 failed!");
    }
}