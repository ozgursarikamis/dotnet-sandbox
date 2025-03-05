using System.Reflection;

namespace ReflectionDeepDive;

public static class InspectingGenericInstances
{
    public static void Run()
    {
        // InspectingGenericClasses();
        InvokingGenericMethods();
    }

    private static void InvokingGenericMethods()
    {
        Type type = typeof(Utility);
        MethodInfo? method = type.GetMethod("Print");
        
        // Make the method generic for type string
        MethodInfo genericMetgod = method.MakeGenericMethod(typeof(string));

        object? instance = Activator.CreateInstance(type);
        genericMetgod.Invoke(instance, new[] { "Hello Reflection! " });
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

internal class Utility
{
    public void Print<T>(T item)
    {
        Console.WriteLine($"📢 Value: {item}, Type: {typeof(T)}");
    }
}