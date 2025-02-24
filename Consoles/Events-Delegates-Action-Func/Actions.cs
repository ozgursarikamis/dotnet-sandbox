namespace Events_Delegates_Action_Func;

public static class Actions
{
    public static void Run()
    {
        var coffeeMachine = new CoffeeMachine();
        
        // Define an Action delegate:
        Action<string> notifyEmployee;
        
        // Assign methods dynamically:
        notifyEmployee = coffeeMachine.NotifyByEmail;
        notifyEmployee += coffeeMachine.NotifyBySpeaker; // becomes Multicast
        
        notifyEmployee("Coffee is ready!");
    }
}

public class CoffeeMachine
{
    public void NotifyByEmail(string message)
    {
        Console.WriteLine($"📧 Email Notification: {message}");
    }

    public void NotifyBySpeaker(string message)
    {
        Console.WriteLine($"🔊 Speaker Announcement: {message}");
    }
}
