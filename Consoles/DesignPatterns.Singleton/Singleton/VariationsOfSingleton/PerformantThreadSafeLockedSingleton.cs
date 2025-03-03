namespace DesignPatterns.Singleton.Singleton.VariationsOfSingleton;

public sealed class PerformantThreadSafeLockedSingleton
{
    private static PerformantThreadSafeLockedSingleton _instance;
    private static readonly object _lock = new object();

    private PerformantThreadSafeLockedSingleton() { }

    public static PerformantThreadSafeLockedSingleton Instance
    {
        get
        {
            if (_instance == null) // First check (No locking if instance is already created)
            {
                lock (_lock)
                {
                    if (_instance == null) // Second check (Ensures only one thread creates an instance)
                    {
                        _instance = new PerformantThreadSafeLockedSingleton();
                    }
                }
            }
            return _instance;
        }
    }
}

// ### ✅ **Advantages:**
//
// - Locks **only when needed** (faster than the previous approach).
// - Works well in **multi-threaded** environments.