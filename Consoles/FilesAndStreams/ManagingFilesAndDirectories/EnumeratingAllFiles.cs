namespace FilesAndStreams.ManagingFilesAndDirectories;

public static class EnumeratingAllFiles
{
    public static void Run()
    {
        const string directoryPath = "TestDirectory";
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            File.WriteAllText(Path.Combine(directoryPath, "file1.txt"), "This is file 1.");
            File.WriteAllText(Path.Combine(directoryPath, "file2.txt"), "This is file 2.");
        }
        
        foreach(var file in Directory.EnumerateFiles(directoryPath))
            Console.WriteLine(file);
    }
}