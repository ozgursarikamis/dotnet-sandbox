namespace AdvancedConcepts.OperatorOverloading;

public static class BasicOperatorOverloading
{
    public static void Run()
    {
        var p1 = new Point { X = 1, Y = 2 };
        var p2 = new Point { X = 2, Y = 3 };

        var p3 = p1 + p2;
        Console.WriteLine($"{p3.X}, {p3.Y}");
    }
}

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }
    
    // Overload the '+' operator to add two Point objects
    public static Point operator +(Point p1, Point p2)
    {
        return new Point { X = p1.X + p2.X, Y = p1.Y + p2.Y };
    }
}