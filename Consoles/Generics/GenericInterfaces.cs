namespace Generics;

public static class GenericInterfaces
{
    public static void Run()
    {
        // GenericInterface();
        GenericInterface2();
    }

    private static void GenericInterface2()
    {
        IRepository<string> stringRepo = new Repository<string>();
        stringRepo.Add("Hello");
        Console.WriteLine(string.Join(", ", stringRepo.GetAll()));
        
        IRepository<int> intRepo = new Repository<int>();
        intRepo.Add(1);
        intRepo.Add(2);
        Console.WriteLine(string.Join(", ", intRepo.GetAll()));
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

interface IRepository<T>
{
    void Add(T entity);
    IEnumerable<T> GetAll();
}

internal class Repository<T> : IRepository<T>
{
    private List<T> _items = [];
    public void Add(T entity) => _items.Add(entity);

    public IEnumerable<T> GetAll() => _items;
}