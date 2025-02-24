namespace Events_Delegates_Action_Func;

public static class MemoryUsage
{
    static int Square(int x) => x * x;
    
    public static void Run()
    {
        long memoryBefore = GC.GetTotalMemory(true);
        Func<int, int> funcSquare = x => x * x;
        
        long memoryAfter = GC.GetTotalMemory(true);
        Console.WriteLine($"Memory used by the delegate: {memoryAfter - memoryBefore} bytes");
    }
}