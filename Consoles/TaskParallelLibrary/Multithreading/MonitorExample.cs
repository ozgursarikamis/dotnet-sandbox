namespace TaskParallelLibrary.Multithreading;

public class MonitorExample
{
    private int _requestCount = 0;
    private readonly object _lockObject = new object();
    
    public void IncrementCounter()
    {
        Monitor.Enter(_lockObject);
        try
        {
            _requestCount++;
        }
        finally
        {
            Monitor.Exit(_lockObject);
        }
    }

    public int GetCount()
    {
        lock (_lockObject)
            return _requestCount;
    }
}