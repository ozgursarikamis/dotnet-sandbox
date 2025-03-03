namespace LazyClass;

public class ThreadSafetyMode
{
    private static readonly Lazy<HeavyObject> _lazyObject =
        new Lazy<HeavyObject>(() => new HeavyObject(), LazyThreadSafetyMode.PublicationOnly);
}

internal class HeavyObject;

// ### **How It Works?**
//
// - Multiple threads **can start initialization** but only **one thread wins**.
// - If multiple threads try to initialize, some may **discard their results**.