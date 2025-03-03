namespace DesignPatterns.Singleton.Singleton.VariationsOfSingleton;

public sealed class PerformantThreadSafeLockedSingleton
{
    private static PerformantThreadSafeLockedSingleton _instance;
    private static readonly object _lock = new object();

    private static PerformantThreadSafeLockedSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null) // double-check!
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