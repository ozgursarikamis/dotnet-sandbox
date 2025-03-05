using System.Reflection;

namespace ReflectionDeepDive;

public static class InspectingMetaData
{
    public static void Run()
    {
        GetMetaData();
    }

    private static void GetMetaData()
    {
        Type type = typeof(SampleClass);
        Console.WriteLine($"Type: {type.FullName}");
        Console.WriteLine($"Name: {type.Name}");
        Console.WriteLine($"Namespace: {type.Namespace}");
        Console.WriteLine($"BaseType: {type.BaseType?.FullName}");

        Console.WriteLine("\nProperties:");
        PropertyInfo[] properties = type.GetProperties();
        foreach (var propertyInfo in properties)
            Console.WriteLine($"\t{propertyInfo.Name}|{propertyInfo.PropertyType.Name}");

        Console.WriteLine("\nMethods:");
        MethodInfo[] methods = type.GetMethods();
        foreach (var methodInfo in methods)
            Console.WriteLine($"\t{methodInfo.Name}|{methodInfo.ReturnType.Name}");
    }
}

internal class SampleClass
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void PrintMessage(string message)
    {
        Console.WriteLine($"Message: {message}");
    }
}