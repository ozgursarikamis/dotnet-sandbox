namespace AdvancedConcepts.PatternMatching;

public class LogicalPatterns // and, is, or
{
    public static void Run()
    {
        Console.WriteLine(CheckTemperature(50));
    }

    static string CheckTemperature(int temperature) => temperature switch
    {
        <= 0 => "Freezing",
        > 0 and <= 30 => "Cold",
        > 30 and <= 60 => "Warm",
        > 70 => "Hot",
    };
}