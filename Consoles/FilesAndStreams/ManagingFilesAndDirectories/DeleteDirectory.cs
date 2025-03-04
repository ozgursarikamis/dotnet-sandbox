namespace FilesAndStreams.ManagingFilesAndDirectories;

public static class DeleteDirectory
{
    public static void Run()
    {
        const string directoryPath = "TestDirectory";
        if (Directory.Exists(directoryPath))
        {
            Directory.Delete(directoryPath, recursive: true);
            Console.WriteLine("Directory deleted");
        }
        else
        {
            Console.WriteLine("Directory does not exist");
        }
    }
}