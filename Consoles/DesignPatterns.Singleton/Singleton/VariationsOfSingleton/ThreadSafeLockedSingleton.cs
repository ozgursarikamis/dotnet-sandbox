namespace DesignPatterns.Singleton.Singleton.VariationsOfSingleton;

public class ThreadSafeLockedSingleton
{
    private static ThreadSafeLockedSingleton _instance;
    private static readonly object _lock = new object();
    
    private ThreadSafeLockedSingleton() {}

    public static ThreadSafeLockedSingleton Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new ThreadSafeLockedSingleton();
                }

                return _instance;
            }
        }
    }
}

// ### ✅ **Improvements:**

// - **Ensures only one instance is created across multiple threads**.
// - **Downside**: Every call to `Instance` locks the object, which can impact performance.