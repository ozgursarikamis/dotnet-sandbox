namespace AdvancedConcepts.IndexesRangesIndices;

public class Ranges
{
    public static void Run()
    {
        BasicRanges();
    }

    private static void BasicRanges()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var range = numbers[2..5]; // starting from 2, not including 5
        foreach (var item in range)
            Console.WriteLine(item);

        Console.WriteLine("==");
        var range2 = numbers[..5]; // until index 5
        foreach (var item in range2)
            Console.WriteLine(item);

        Console.WriteLine("==");
        const string message = "Hello, World!";
        var substring = message[..5];
        Console.WriteLine(substring);
        
        var lastThreeElements = message[^3];
        Console.WriteLine(lastThreeElements);
    }
}