namespace DesignPatterns.Singleton.Singleton;

// 1️⃣ Basic (Non-Thread-Safe) Singleton ❌ (Not Recommended)
public class BasicSingleton
{
    private static BasicSingleton _instance;
    private BasicSingleton() {}

    public static BasicSingleton GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BasicSingleton();
            }

            return _instance;
        }
    }
}

// Not thread-safe: If two threads access Instance simultaneously,
// both could create a separate instance.