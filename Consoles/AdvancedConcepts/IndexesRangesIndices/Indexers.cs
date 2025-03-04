namespace AdvancedConcepts.IndexesRangesIndices;

public class Indexers
{
    public static void Run()
    {
        var myObj = new IntIndexerClass();
        myObj[0] = 100;
        myObj[1] = 200;
        myObj[2] = 300;
        Console.WriteLine(myObj[0]);
        
        var stringIndexer = new StringIndexerClass();
        stringIndexer["apple"] = 99;
        stringIndexer["banana"] = 199;

        Console.WriteLine(stringIndexer["apple"]);
        Console.WriteLine(stringIndexer["banana"]);
    }

    private class IntIndexerClass
    {
        private readonly int[] _array = new int[10];

        public int this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }
    }

    private class StringIndexerClass
    {
        private Dictionary<string, int> _dictionary = new Dictionary<string, int>();

        public int this[string key]
        {
            get { return _dictionary.ContainsKey(key) ? _dictionary[key] : 0; }
            set { _dictionary[key] = value; }
        }
    }
}