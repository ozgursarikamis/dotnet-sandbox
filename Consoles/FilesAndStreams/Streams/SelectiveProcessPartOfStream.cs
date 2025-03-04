namespace FilesAndStreams.Streams;

public static class SelectiveProcessPartOfStream
{
    public static void Run()
    {
        using (FileStream fs = File.OpenRead("stream_example.txt"))
        {
            byte[] buffer = new byte[1024];
            fs.Read(buffer, 0, buffer.Length);

            Console.WriteLine($"First 10 bytes as text: {System.Text.Encoding.UTF8.GetString(buffer)}");
        }
    }
}