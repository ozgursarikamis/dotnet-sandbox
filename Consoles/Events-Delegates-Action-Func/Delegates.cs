namespace Events_Delegates_Action_Func;

public static class Delegates
{
    public static void Run()
    {
        RunDelegates();
    }

    private static void RunDelegates()
    {
        var station = new NewsStation();
        
        // Create delegate instance and assign method
        NotifyDelegate notifier = station.SendNews;
        
        // Add another method to the delegate (Multicast)
        notifier += station.SendWeatherUpdate;
        
        // Invoke the delegate (This will call both methods)
        notifier("Rain expected tomorrow.");
    }
}

public delegate void NotifyDelegate(string message);

public class NewsStation
{
    public void SendNews(string news)
    {
        Console.WriteLine($"Breaking news {news}");
    }

    public void SendWeatherUpdate(string update)
    {
        Console.WriteLine($"Weather update: {update}");
    }
}