namespace FilesAndStreams.ManagingFilesAndDirectories;

public static class CopyingFile
{
    public static void Run()
    {
        const string sourceFile = "source.txt";
        const string destinationFile = "destination.txt";
        
        // Ensure the source file exists
        if (!File.Exists(sourceFile))
            File.WriteAllText(sourceFile, "This is a sample file.");
        
        // Copy the file:
        File.Copy(sourceFile, destinationFile, overwrite: true);
        Console.WriteLine("File copied to " + destinationFile);
    }
}

