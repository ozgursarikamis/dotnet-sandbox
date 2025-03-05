namespace Generics;

public static class SwapUtility
{
    public static void Run()
    {
        var x = 10;
        var y = 20;
        Utils.Swap(ref x, ref y);
        Console.WriteLine($"x: {x}, y: {y}");
    }
}

internal class Utils
{
    public static void Swap<T>(ref T a, ref T b)
    {
        
        T temp = a;
        a = b;
        b = temp;
        
        // OR:
        // (a, b) = (b, a);
    }
}