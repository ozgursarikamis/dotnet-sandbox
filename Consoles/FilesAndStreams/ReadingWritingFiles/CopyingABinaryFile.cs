namespace FilesAndStreams.ReadingWritingFiles;

public static class CopyingABinaryFile
{
    public static void Run()
    {
        const string source = "source.png";
        const string destination = "destination.png";
        
        // Read entire binary file:
        byte[] sourceBytes = File.ReadAllBytes(source);
        
        // Write to new location:
        File.WriteAllBytes(destination, sourceBytes);
        Console.WriteLine("Source file is copied to destination");
    }
}