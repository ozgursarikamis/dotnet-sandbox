namespace Generics;

public static class GenericEvents
{
    public static void Run()
    {
        SubscribeAndHandleEvent();
    }

    private static void SubscribeAndHandleEvent()
    {
        var stringPublisher = new EventPublisher<string>();
        stringPublisher.DataReceived += (sender, e) =>
        {
            Console.WriteLine($"String Event Received: {e.Data}");
        };
        
        var intPublisher = new EventPublisher<int>();
        intPublisher.DataReceived += (sender, e) =>
        {
            Console.WriteLine($"Int Event Received: {e.Data}");
        };

        stringPublisher.Publish("Hello Generic Events!");
        intPublisher.Publish(10);
    }
}

internal class EventData<T> : EventArgs
{
    public T Data { get; }
    public EventData(T data) => Data = data;
}

internal class EventPublisher<T>
{
    public event EventHandler<EventData<T>>? DataReceived;
    
    public void Publish(T data)
    {
        Console.WriteLine($"Publishing event with data: {data}");
        DataReceived?.Invoke(this, new EventData<T>(data));
    }
}