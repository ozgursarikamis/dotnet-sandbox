namespace DesignPatterns.Singleton.Singleton.VariationsOfSingleton;

public sealed class EagerInitializationSingleton
{
    private static readonly EagerInitializationSingleton _instance = new EagerInitializationSingleton();
    private EagerInitializationSingleton() {}
    public static EagerInitializationSingleton Instance => _instance;
}

// ### ✅ **Advantages:**
//
// - **Simple and thread-safe**.
// - **No locks** needed.
//     - **Best when the instance is lightweight** and **always needed**.
//
// ### ❌ **Disadvantages:**
//
// - If the instance **isn’t used**, it still gets created, potentially wasting resources.

// For an improved version, check LazyInitializationSingleton.cs