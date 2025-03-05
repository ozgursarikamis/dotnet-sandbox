using System.Reflection;

namespace ReflectionDeepDive.ManipulatingObjects;

public static class ModifyingPrivateFields
{
    public static void Run()
    {
        // Create instance
        object secret = Activator.CreateInstance<Secret>();

        // Get Type
        var type = secret.GetType();

        // Get private field
        var field = type.GetField("_hiddenMessage", BindingFlags.NonPublic | BindingFlags.Instance);

        // Get field value
        var value = (string)field?.GetValue(secret)!;
        Console.WriteLine($"Before: {value}");

        // Modify field value
        field?.SetValue(secret, "New Secret Message");

        // Get new value
        value = (string)field?.GetValue(secret)!;
        Console.WriteLine($"After: {value}");
    }
}

public class Secret
{
    private string _hiddenMessage = "This is private";
}