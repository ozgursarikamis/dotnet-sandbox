namespace FilesAndStreams.Streams;

public static class ReadingWritingData
{
    public static void Run()
    {
        WriteData();
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