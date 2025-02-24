namespace Events_Delegates_Action_Func;

public class FunctionalProgrammingConcepts
{
    public static void Run()
    {
        Func<int, int> doubleIt = x => x * 2;
        Func<int, int> addFive = x => x + 5;
        
        var doubleThenAddFive = Compose(doubleIt, addFive);
        Console.WriteLine(doubleThenAddFive(10)); // 25
    }

    private static Func<int, int> Compose(Func<int, int> f1, Func<int, int> f2)
    {
        return x => f2(f1(x)); // Applying f1 first, then f2
    }

}