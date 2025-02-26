namespace TaskParallelLibrary.Basics;

public static class TaskBasics
{
    public static void Run()
    {
        Task.Run(() =>
        {
            Console.WriteLine("Task started");

            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine($"Task: {i}");
                Task.Delay(500).Wait(); // simulating work. keeps the CURRENT thread blocked.
            }

            Console.WriteLine("Task completed");
        });
        
        Console.WriteLine("Main thread continues...");
        Console.ReadKey();
    }
}