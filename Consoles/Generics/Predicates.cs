namespace Generics;

public static class Predicates
{
    public static void Run()
    {
        PredicateBasics();
    }

    private static void PredicateBasics()
    {
        var numbers = new List<int> { 10, 25, 30, 40, 50 };
        List<int> evenNumbers = numbers.FindAll(IsEven);
        List<int> oddNumbers = numbers.FindAll(IsOdd);
        Console.WriteLine(string.Join(", ", evenNumbers));
        Console.WriteLine(string.Join(", ", oddNumbers));
        return;

        // Predicates
        static bool IsEven(int number) => number % 2 == 0;
        static bool IsOdd(int number) => number % 2 != 0;
    }
}