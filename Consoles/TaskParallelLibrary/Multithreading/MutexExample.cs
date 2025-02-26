namespace TaskParallelLibrary.Multithreading;

/*
 - Similar to `lock`, but can be used for inter-process synchronization.
 - Slower than `lock` because it involves operating system calls.
*/

public static class MutexExample
{
    private static Mutex? _mutex;
    private const string MutexName = "MySharedResourceMutex";

    public static void AccessSharedResource()
    {
        try
        {
            // Attempt to acquire the mutex:
            _mutex = Mutex.OpenExisting(MutexName);
        }
        catch (WaitHandleCannotBeOpenedException e)
        {
            // Mutex doesn't exist, create it:
            _mutex = new Mutex(false, MutexName);
        }

        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} attempting to acquire mutex.");
        _mutex.WaitOne(); // acquire the mutex

        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} acquired mutex. Accessing shared resource.");
        _mutex.ReleaseMutex();
    }
}