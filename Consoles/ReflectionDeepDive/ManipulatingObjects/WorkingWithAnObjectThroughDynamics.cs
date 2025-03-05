using System.Reflection;

namespace ReflectionDeepDive.ManipulatingObjects;

public static class WorkingWithAnObjectThroughDynamics
{
    public static void Run()
    {
        Type type = typeof(Robot);

        dynamic robot = Activator.CreateInstance(type, "XYZ-900");

        // call method dynamically.
        // We don’t need casting ((Robot)instance is not required).
        // We can call methods without needing type information at compile time.

        robot?.Identify();
    }
}

internal class Robot
{
    private string model;

    public Robot(string model)
    {
        this.model = model;
    }

    public void Identify()
    {
        Console.WriteLine($"I am a {model} robot.");
    }
}