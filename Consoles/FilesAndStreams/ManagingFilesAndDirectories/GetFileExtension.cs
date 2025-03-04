namespace FilesAndStreams.ManagingFilesAndDirectories;

public static class GetFileExtension
{
    public static void Run()
    {
        const string filePath = "example.xyz";
        var extension = Path.GetExtension(filePath);
        Console.WriteLine($"File extension: {extension}");
    }
}