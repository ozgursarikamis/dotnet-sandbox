namespace Generics;

public static class GenericClasses
{
    public static void Run()
    {
        // UsingGenericClass();
        GenericNotifier();
    }

    private static void GenericNotifier()
    {
        var emailNotifier = new Notifier<EmailNotification>();
        emailNotifier.Send(new EmailNotification { Message = "You've got mail", Email = "test@email.com" });
        
        var smsNotifier = new Notifier<SMSNotification>();
        smsNotifier.Send(new SMSNotification { Message = "Your OTP is 1234", PhoneNumber = "12345" });
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

public class Notification { public string Message { get; set; } }
public class EmailNotification : Notification { public string Email { get; set; } }
public class SMSNotification : Notification { public string PhoneNumber { get; set; } }

public class Notifier<T> where T : Notification
{
    public void Send(T notification)
    {
        Console.WriteLine($"Sending notification: {notification.Message}");
    }
}