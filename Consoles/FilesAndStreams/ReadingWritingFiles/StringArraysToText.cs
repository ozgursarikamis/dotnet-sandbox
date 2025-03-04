namespace FilesAndStreams.ReadingWritingFiles;

public static class StringArraysToText
{
    public static void Run()
    {
        const string path = "lines.txt";
        string[] lines = { "First line", "Second line", "Third line" };
        
        // Write array of lines
        File.WriteAllLines(path, lines);
        Console.WriteLine("Lines written");
        
        // Read lines back
        string[] readLines = File.ReadAllLines(path);
        Console.WriteLine("File contents:");

        foreach (var line in readLines)
        {
            Console.WriteLine(line);
        }
    }
}