namespace AdvancedConcepts.IndexesRangesIndices;

public class Spans
{
    public static void Run()
    {
        // Example1();
        // SpanSlice();
        // ModifySpan();
        // StackAllocatedSpan();
        // SpanWithStrings();
        PerformanceCriticalScenario();
    }

    private static void PerformanceCriticalScenario()
    {
        var numbers = new int[1_000_000];
        for (var i = 0; i < numbers.Length; i++)
            numbers[i] = i;
        
        Span<int> span = numbers.AsSpan();
        Span<int> slice = span.Slice(500_000, 100); // Take a slice of the array.
        
        // Modify the slice
        for (var i = 0; i < slice.Length; i++)
            slice[i] *= 2; // Double each value in the slice

        Console.WriteLine($"Modified value at index 500000: {numbers[500000]}");
    }

    private static void SpanWithStrings()
    {
        const string message = "Hello, World";
        var span = message.AsSpan();

        var sliced = span.Slice(7, 5);
        Console.WriteLine(sliced.ToString()); // World
    }

    private static void StackAllocatedSpan()
    {
        // Allocating memory on the stack
        Span<int> span = stackalloc int[3]; // capacity
        // This means that you can avoid heap allocations for certain scenarios,
        // making your code even more efficient.
        
        span[0] = 1;
        span[1] = 2;
        span[2] = 3;

        Console.WriteLine("Stack allocated span");
        foreach (var i in span)
        {
            Console.WriteLine(i);
        }
    }

    private static void ModifySpan()
    {
        int[] numbers = { 10, 20, 30, 40, 50 };
        Span<int> span = numbers.AsSpan();
        span[0] = 100;
        foreach (var i in span)
            Console.WriteLine(i);
    }

    private static void SpanSlice()
    {
        int[] numbers = { 10, 20, 30, 40, 50 };
        Span<int> numbersSpan = numbers;
        
        // Slice the Span to get elements from index 1 to 3 (exclusive of 3)
        // Elements at index 1 and 2 (20, 30)
        Span<int> slice = numbersSpan.Slice(1, 2);
        Console.WriteLine("Slice");
        foreach (var i in slice)
            Console.WriteLine(i);
    }

    private static void Example1()
    {
        int[] numbers = { 10, 20, 30, 40, 50 };
        Span<int> span = numbers;

        foreach (var item in span)
            Console.WriteLine(item);
        
        // In this example, span gives us a view into the numbers array,
        // allowing us to access and manipulate the elements without allocating new memory.
    }
}

