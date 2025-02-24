namespace Events_Delegates_Action_Func;

public class Events
{
    public static void Run()
    {
        var laptopBattery = new Battery();
        
        // Subscribe to the event handlers:
        laptopBattery.OnBatteryLow += DisplayWarning;
        laptopBattery.OnBatteryLow += SaveWork;
        laptopBattery.OnBatteryLow += ShutdownSystem;

        laptopBattery.Level = 25; // No event is triggered.
        Console.WriteLine("Battery is draining...");
        laptopBattery.Level = 15;
    }
    
    static void DisplayWarning(object sender, int level) =>
        Console.WriteLine($"⚠️ Warning: Battery low ({level}%)!");

    static void SaveWork(object sender, int level) =>
        Console.WriteLine("💾 Saving work to prevent data loss...");

    static void ShutdownSystem(object sender, int level) =>
        Console.WriteLine("🔌 Shutting down to protect battery life.");
}

class Battery
{
    public event EventHandler<int> OnBatteryLow;

    private int _level;

    public int Level
    {
        get => _level;
        set
        {
            _level = value;
            if (_level < 20)
            {
                OnBatteryLow.Invoke(this, _level);
            }
        }
    }
}