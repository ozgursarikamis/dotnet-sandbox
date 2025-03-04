using System.Diagnostics.CodeAnalysis;

namespace AdvancedConcepts;

public static class NotNullWhenAttr
{
    public static void Run()
    {
        if (Example.TryParse(" Hello ", out string? parsedValue))
        {
            // The compiler knows parsedValue is not null here:
            Console.WriteLine(parsedValue.Length);
        }
        else
        {
            // The compiler knows parsedValue is null here:
            Console.WriteLine("Parsing failed");
        }
    }
}

internal static class Example
{
    public static bool TryParse(string? input, [NotNullWhen(true)] out string? result)
    {
        if (!string.IsNullOrEmpty(input))
        {
            result = input.Trim();
            return true;
        }
        result = null;
        return false;
    }
}