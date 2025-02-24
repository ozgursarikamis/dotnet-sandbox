namespace Events_Delegates_Action_Func;
// Now, let’s explore more advanced use cases of Action<T> and Func<T>, focusing on:

// Event Handling 🛎️
// Dependency Injection 🏗️
// Functional Programming Concepts 🧠

public static class AdvancedUseCases
{
    public static void Run()
    {
        var button = new Button();
        
        // Subscribe to the event using Action:
        button.OnClick += () => Console.WriteLine("✅ Button Clicked!");
        button.OnClick += () => Console.WriteLine("🔔 Playing Click Sound...");
        button.OnClick += () => Console.WriteLine("📨 Sending Analytics Data...");
        
        button.Click();
    }
}

class Button
{
    public event Action? OnClick; // Event using Action

    public void Click()
    {
        OnClick?.Invoke();
    }
}