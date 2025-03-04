namespace AdvancedConcepts.Tuples;

public static class Tuples
{
    public static void Run()
    {
        // CreateTuples();
        // NamedTuples();
        var tuples = ReturningTuples();
        Console.WriteLine($"tuples: {tuples.Item1},{tuples.Item2},{tuples.Item3}");
    }

    private static (int, string, bool) ReturningTuples()
    {
        return (0, "Name", false);
    }

    private static void NamedTuples()
    {
        // Named Tuples (C# 7.0 and later)
        var myNamedTuple = (Id: 1, Name: "Ally", Age: 2);
        Console.WriteLine($"myNamedTuple: {myNamedTuple.Id} {myNamedTuple.Name} {myNamedTuple.Age}");
    }

    private static void CreateTuples()
    {
        var myTuple = Tuple.Create(1, "Hello", "World", false);
        Console.WriteLine($"myTuple: {myTuple.Item1} , {myTuple.Item2} , {myTuple.Item3}");
    }
}