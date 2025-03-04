namespace AdvancedConcepts.GarbageCollection;

public class IDisposableImplementation
{
    public static void Run()
    {
        // var manager = new FileManager("data.txt");
        // manager.Dispose();
        
        // or use `using` so that Dispose() is called automatically:
        using var fileManager = new FileManager("data.txt", FileMode.Open);
    }
}

class FileManager : IDisposable
{
    private FileStream _fileStream;

    public FileManager(string filePath, FileMode open)
    {
        _fileStream = new FileStream(filePath, FileMode.Open);
    }
    
    public void Dispose()
    {
        _fileStream.Dispose();
        Console.WriteLine("File closed");
        
        // Suppress finalization since Dispose() has already cleaned up resources.
        GC.SuppressFinalize(this);
        
        // By calling GC.SuppressFinalize(this), you inform the garbage collector
        // that the finalizer does not need to be called, which can improve performance.
    }
}