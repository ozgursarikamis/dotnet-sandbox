namespace ReflectionDeepDive;

public static class InspectingGenericInstances
{
    public static void Run()
    {
        InspectingGenericClasses();
    }

    private static void InspectingGenericClasses()
    {
        Type type = typeof(DataStore<int>);
        Console.WriteLine($"📌 Type Name: {type.Name}");
        Console.WriteLine($"📌 Is Generic? {type.IsGenericType}");
        
        Type genericDefinition = type.GetGenericTypeDefinition();
        Console.WriteLine($"📌 Generic Definition: {genericDefinition}");

        Type[] genericArgs = type.GetGenericArguments();
        Console.WriteLine($"📌 Generic Argument: {genericArgs[0]}");
    }
}

internal class DataStore<T>
{
    public T Data { get; set; }
}