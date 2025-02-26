namespace TaskParallelLibrary;

public class AggregateExceptionExample
{
    public static void Run()
    {
        Task task1 = Task.Run(() => throw new InvalidOperationException("Task 1 failed"));
        Task task2 = Task.Run(() => throw new ArgumentException("Task 2 failed"));

        Task allTasks = Task.WhenAll(task1, task2);

        try
        {
            allTasks.Wait(); // Forces all exceptions to surface
        }
        catch (AggregateException aggEx)
        {
            foreach (var ex in aggEx.InnerExceptions)
            {
                Console.WriteLine($"Caught: {ex.GetType().Name} - {ex.Message}");
            }
            
            //or flatten the AggregateException:
            foreach (var exception in aggEx.Flatten().InnerExceptions)
            {
                Console.WriteLine($"Exception: {exception.Message}");
            }
        }
    }
}