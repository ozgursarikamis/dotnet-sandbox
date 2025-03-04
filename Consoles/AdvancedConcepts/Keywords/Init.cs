namespace AdvancedConcepts.Keywords;

public static class Init
{
    public static void Run()
    {
        System.Console.WriteLine("Init keyword");
        // Allowed:
        var person = new PersonInit{ Age = 30, Name = "Alice"};

        // ❌ Compilation error: Cannot modify init-only properties after initialization
        // person.Name = "Bob";
    }
}

public class PersonInit {
    public string Name { get; init; } = "Unknown";
    public int Age { get; set; }
}