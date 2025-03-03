namespace DesignPatterns.Singleton.Singleton.VariationsOfSingleton;

public sealed class LazyInitializationSingleton
{
    private static readonly Lazy<LazyInitializationSingleton> _instance 
        = new Lazy<LazyInitializationSingleton>(() => new LazyInitializationSingleton());
    
    private LazyInitializationSingleton() { }
    
    public static LazyInitializationSingleton Instance => _instance.Value;
}

// ### ✅ **Why is this the best approach?**
//
// - **Thread-safe** without locks.
// - **Lazy initialization** (only created when first accessed).
// - **Efficient in terms of memory and performance**.