namespace AdvancedConcepts.OperatorOverloading;

public static class BasicOperatorOverloading
{
    public static void Run()
    {
        var p1 = new Point { X = 1, Y = 2 };
        var p2 = new Point { X = 2, Y = 3 };

        var p3 = p1 + p2;
        Console.WriteLine($"{p3.X}, {p3.Y}");
        
        var p3p2 = p3 == p2;
        Console.WriteLine($"p3p2: {p3p2}");
        
        var p4 = new Point { X = 2, Y = 3 };
        var p4p2 = p4 == p2;
        Console.WriteLine($"p4p2: {p4p2}");
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

    public static bool operator ==(Point p1, Point p2)
    {
        return p1.X == p2.X && p1.Y == p2.Y;
    }
    
    public static bool operator !=(Point p1, Point p2)
    {
        return !(p1 == p2); // reuse the '==' operator
    }
    
    // You should also override Equals() and GetHashCode() for consistency
    public override bool Equals(object? obj)
    {
        if (obj is Point point)
        {
            return this == point;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode();
    }
}