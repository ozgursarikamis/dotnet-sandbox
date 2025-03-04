namespace AdvancedConcepts.PatternMatching;

public class RelationalPatterns
{
    public static void Run()
    {
        Console.WriteLine(DescribeAge(1));  
        Console.WriteLine(DescribeAge(17));  
        Console.WriteLine(DescribeAge(21));  
        Console.WriteLine(DescribeAge(65));  
    }

    static string DescribeAge(int age) => age switch
    {
        < 13 => "Child",
        >= 13 and <= 18 => "Teen",
        > 18 and <= 65 => "Adult",
        _ => "Senior"
    };
}