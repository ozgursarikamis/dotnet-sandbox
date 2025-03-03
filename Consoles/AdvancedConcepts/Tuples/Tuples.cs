namespace AdvancedConcepts.Tuples;

public static class Tuples
{
    public static void Run()
    {
        CreateTuples();
    }

    private static void CreateTuples()
    {
        var myTuple = Tuple.Create(1, "Hello", "World", false);
        Console.WriteLine($"myTuple: {myTuple.Item1} , {myTuple.Item2} , {myTuple.Item3}");
    }
}