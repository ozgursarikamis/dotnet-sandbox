namespace FilesAndStreams.ManagingFilesAndDirectories;

public static class MovingFile
{
    public static void Run()
    {
        const string sourceFile = "source.txt";
        const string movedFile = "moved.txt";

        if (File.Exists(sourceFile))
        {
            File.Move(sourceFile, movedFile);
            Console.WriteLine("File moved to " + movedFile);
        }
        else
        {
            Console.WriteLine("File does not exist.");
        }
    }
}