namespace Generics;

public static class Predicates
{
    public static void Run()
    {
        // PredicateBasics();
        PredicateDefinition();
    }

    private static void PredicateDefinition()
    {
        // Predicate<T>
        Point?[] points =
        {
            new(100, 200),
            new(150, 250),
            new(200, 300),
            new(300, 400),
        };
        
        // Define a Predicate<T> delegate:
        Predicate<Point> predicate = FindPoints;
        Point? first = Array.Find(points, predicate!);

        Console.WriteLine($"{first?.X}, {first?.Y}");
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

    private static bool FindPoints(Point p)
    {
        return p.X * p.Y > 100_000;
    }
}

internal class Point(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
}