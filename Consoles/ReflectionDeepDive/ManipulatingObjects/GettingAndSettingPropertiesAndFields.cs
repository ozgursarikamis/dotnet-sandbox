using System.Reflection;

namespace ReflectionDeepDive.ManipulatingObjects;

public static class GettingAndSettingPropertiesAndFields
{
    public static void Run()
    {
        object car = Activator.CreateInstance(typeof(Car));

        Type type = car.GetType();

        PropertyInfo propertyInfo = type.GetProperty("Model");
        propertyInfo?.SetValue(car, "Tesla Model X");
        
        // Get property value:
        var model = (string)propertyInfo.GetValue(car);
        Console.WriteLine();
        Console.WriteLine($"Car Model: {model}");
    }
}

internal class Car
{
    public string Model { get; set; }
}