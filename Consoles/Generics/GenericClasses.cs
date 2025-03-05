namespace Generics;

public static class GenericClasses
{
    public static void Run()
    {
        UsingGenericClass();
    }

    private static void UsingGenericClass()
    {
        var userRepo = new GenericRepository<User>();
        userRepo.Add(new User { Name = "Alice" });

        var productRepo = new GenericRepository<Product>();
        productRepo.Add(new Product { Title = "Laptop" });
    }
}

internal class GenericRepository<T>
{
    private List<T> _items = new List<T>();

    public void Add(T item)
    {
        _items.Add(item);
        Console.WriteLine($"Added item: {typeof(T).Name}");
    }

    public List<T> GetAll() => _items;
}

internal class Product
{
    public string Title { get; set; }
}