namespace FilesAndStreams.Streams;

public static class ReadingWritingData
{
    public static void Run()
    {
        // WriteData();
        ReadData();
    }

    private static void ReadData()
    {
        // 📌 Use Case: Useful when processing line-by-line
        // instead of loading everything into memory.
        using (var reader = new StreamReader("stream_example.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }

    private static void WriteData()
    {
        const string path = "stream_example.txt";
        
        using var writer = new StreamWriter(path);
        writer.WriteLine("Hello World!");
        writer.WriteLine("Streams allow efficient data handling");

        Console.WriteLine("File is written successfully");
    }
}