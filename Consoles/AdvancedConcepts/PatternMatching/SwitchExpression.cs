namespace AdvancedConcepts.PatternMatching;

public class SwitchExpression
{
    public static void Run()
    {
        Console.WriteLine(GetDescription(10));
        Console.WriteLine(GetDescription(false));
        Console.WriteLine(GetDescription(null));
        Console.WriteLine(GetDescription(long.MaxValue));
    }

    private static string GetDescription(object obj) => obj switch
    {
        int i => $"It's an integer: {i}",
        string s => $"It's a string: {s}",
        long l => $"It's a long: {l}",
        null => $"It's null",
        _ => $"It's a {obj.GetType().Name}"
    };
}