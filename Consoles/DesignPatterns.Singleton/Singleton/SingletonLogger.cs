namespace DesignPatterns.Singleton.Singleton;

public sealed class SingletonLogger
{
    // Private static instance of the same class
    private static readonly Lazy<SingletonLogger> instance = new(() => new SingletonLogger());
    
    // Private constructor ensures that the class cannot be instantiated outside:
    public SingletonLogger()
    {
        Console.WriteLine("Singleton Logger initialized");
    }
    
    // public method to get single instance:
    public static SingletonLogger Instance => instance.Value;
    
    // Example method to log messages:
    public static void Log(string message)
    {
        Console.WriteLine($"Log: [{DateTime.Now:HH:mm:ss}] {message}");
    }
}