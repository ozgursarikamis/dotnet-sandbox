namespace TaskParallelLibrary.Multithreading;

public class RequestCounter
{
    private int _requestCount = 0;
    private readonly Lock _lockObject = new();

    public void IncrementCounter()
    {
        lock (_lockObject)
        {
            _requestCount++;
        }
    }

    public int GetCount()
    {
        lock (_lockObject)
        {
            return _requestCount;
        }
    }
}