namespace DesignPatterns.Singleton.Singleton;

public static class SingletonDefinition
{
    public static void Run()
    {
        var logger = SingletonLogger.Instance;
        SingletonLogger.Log("First log message");

        var logger2 = SingletonLogger.Instance;
        SingletonLogger.Log("Second log message");

        // Check if both instances are the same:
        Console.WriteLine($"Are both instances the same {logger == logger2}");
    }
}