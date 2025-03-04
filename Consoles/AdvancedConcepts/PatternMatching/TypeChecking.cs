namespace AdvancedConcepts.PatternMatching;

public static class TypeChecking
{
    public static void Run()
    {
        User customer = new Customer { Name = "Alice", LoyaltyPoints = 150 };
        User admin = new Admin { Name = "Bob", HasFullAccess = true };
        User guest = new Guest { Name = "Charlie", IsAnonymous = false };
        User anonymousGuest = new Guest { Name = "Unknown", IsAnonymous = true };

        ProcessUser(customer);       // Output: Welcome, Alice! You have 150 loyalty points.
        ProcessUser(admin);          // Output: Hello, Admin Bob. You have full access.
        ProcessUser(guest);          // Output: Welcome, Charlie! Enjoy browsing.
        ProcessUser(anonymousGuest); // Output: Welcome, Guest! Please sign up for a better experience.

    }

    static void ProcessUser(User user)
    {
        if (user is Customer customer)
        {
            Console.WriteLine($"Customer: {customer.Name}");
        }
        else if (user is Admin admin && admin.HasFullAccess)
        {
            Console.WriteLine($"Admin: {admin.Name}");
        } // Equally:
        else if (user is Admin { HasFullAccess: true })
        {
            Console.WriteLine($"Admin: {user.Name}");
        } else if (user is Guest { IsAnonymous: true })
        {
            Console.WriteLine($"Guest: {user.Name}, You are anonymous");
        } else if (user is Guest)
        {
            Console.WriteLine($"Guest: {user.Name}");
        }
        else
        {
            Console.WriteLine($"Unknown User: {user.Name}");
        }
    }
}

public abstract class User
{
    public string Name { get; set; }
}

public class Customer : User
{
    public int LoyaltyPoints { get; set; }
}

public class Admin : User
{
    public bool HasFullAccess { get; set; }
}

public class Guest : User
{
    public bool IsAnonymous { get; set; }
}