namespace FilesAndStreams.Streams;

public static class RandomFileAccess
{
    public static void Run()
    {
        // WritingAndSeeking();
        ReadingFromASpecificPosition();
    }

    private static void ReadingFromASpecificPosition()
    {
        using (var fs = new FileStream("random_access.dat", FileMode.Open))
        { 
            fs.Seek(5, SeekOrigin.Begin);
            Console.WriteLine("Character at position 5: " + (char)fs.ReadByte());
        }
    }

    private static void WritingAndSeeking()
    {
        using var fs = new FileStream("random_access.dat", FileMode.Create);
        byte[] data = System.Text.Encoding.UTF8.GetBytes("Hello World");
        fs.Write(data, 0, data.Length);
            
        // Move back to position 5 and overwrite:
        fs.Seek(5, SeekOrigin.Begin);
        fs.WriteByte((byte)'X');
    }
}