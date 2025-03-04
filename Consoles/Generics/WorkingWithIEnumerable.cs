using System.Collections;

namespace Generics;

public static class WorkingWithIEnumerable
{
    public static void Run()
    {
        IterateNumberCollection();
    }

    private static void IterateNumberCollection()
    {
        // Now, we can iterate over NumberCollection:
        var numbers = new NumberCollection();
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}

class NumberCollection : IEnumerable<int>
{
    private List<int> _numbers = [1, 2, 3, 4, 5];
    public  IEnumerator<int> GetEnumerator() => _numbers.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _numbers.GetEnumerator();
    
    /*     
       IEnumerable<T> allows creating iterable collections.
       It provides lazy evaluation, meaning elements are accessed only when needed.
     */
}