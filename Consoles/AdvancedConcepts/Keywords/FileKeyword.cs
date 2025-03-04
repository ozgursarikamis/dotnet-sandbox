namespace AdvancedConcepts.Keywords;

public class FileKeyword
{
    public static void Run()
    {
        var message = FileScopedHelper.GetMessage();
        Console.WriteLine(message);
    }
}

file class FileScopedHelper
{
    public static string GetMessage() => "Hello from FileScopedHelper";
}