namespace TaskParallelLibrary.Multithreading;

public class ReaderWriterLockSlimExample
{
    public static async Task Run()
    {
        var cache = new ReaderWriterLockSlimExample();
        
        // Simulate multiple readers and a writer:

        await Task.WhenAll(
            Task.Run(() => { for (int i = 0; i < 5; i++) { cache.ReadData(); Task.Delay(100).Wait(); } }),
            Task.Run(() => { for (int i = 0; i < 5; i++) { cache.ReadData(); Task.Delay(100).Wait(); } }),
            Task.Run(() => { cache.WriteData("Updated Data"); Task.Delay(500).Wait(); }),
            Task.Run(() => { for (int i = 0; i < 5; i++) { cache.ReadData(); Task.Delay(100).Wait(); } })
            );
    }

    private readonly ReaderWriterLockSlim _cacheLock = new();
    private string _cachedData = "Initial data";

    private string ReadData()
    {
        _cacheLock.EnterReadLock();
        var threadId = Environment.CurrentManagedThreadId;
        try
        {
            Console.WriteLine($"Thread {threadId} reading data: {_cachedData}");
            return _cachedData;
        }
        finally
        {
            _cacheLock.ExitReadLock();
        }
    }

    public void WriteData(string newData)
    {
        _cacheLock.EnterWriteLock();
        var threadId = Environment.CurrentManagedThreadId;
        try
        {
            Console.WriteLine($"Thread {threadId} writing data: {newData}");
            _cachedData = newData;
        }
        finally
        {
            _cacheLock.ExitWriteLock();
        }
    }
}