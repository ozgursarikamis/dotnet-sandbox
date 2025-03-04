namespace Generics;

public static class GenericInterfaces
{
    public static void Run()
    {
        GenericInterface();
    }

    private static void GenericInterface()
    {
        var stringLogger = new ConsoleLogger<string>();
        stringLogger.Log("Hello generic interface");
        
        var longLogger = new ConsoleLogger<long>();
        longLogger.Log(long.MaxValue);
    }
}

class ConsoleLogger<T> : ILogger<T>
{
    public void Log(T message)
    {
        Console.WriteLine($"[{DateTime.Now}]: {message}");
    }
}

interface ILogger<T>
{
    void Log(T message);
}