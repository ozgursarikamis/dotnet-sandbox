namespace AdvancedConcepts.PatternMatching;

public class ListPatterns
{
    public static void Run()
    {
        int[] numbers = { 1, 2, 3 };
        int[] numbers2 = { 0, 1, 3 };
        int[] numbers3 = { 0, 5, 4 };
        
        Console.WriteLine(CheckList(numbers));
        Console.WriteLine(CheckList(numbers2));
        Console.WriteLine(CheckList(numbers3));
    }

    private static string CheckList(int[] arr) => arr switch
    {
        [1, 2, 3] => "Sequence matched",
        [_, _, 3] => "I can only verify that it ends with 3",
        _ => "Sorry, no match"
    };
}