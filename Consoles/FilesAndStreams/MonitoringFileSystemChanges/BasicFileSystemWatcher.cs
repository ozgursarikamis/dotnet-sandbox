namespace FilesAndStreams.MonitoringFileSystemChanges;

public static class BasicFileSystemWatcher
{
    public static void Run()
    {
        const string path = "WatchedFolder";
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        var watcher = new FileSystemWatcher(path);
        
        watcher.Created += (s, e) => Console.WriteLine("Created: " + e.FullPath);
        watcher.Changed += (s, e) => Console.WriteLine("Changed: " + e.FullPath);
        watcher.Deleted += (s, e) => Console.WriteLine("Deleted: " + e.FullPath);
        watcher.Renamed += (s, e) => Console.WriteLine($"Renamed: {e.OldName} to {e.FullPath}");
        
        watcher.InternalBufferSize = 64 * 1024; // 64 KB Buffer size
        
        // By default, FileSystemWatcher watches all file attributes.
        // You can filter it to monitor only specific changes.
        watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
        
        // automatically processing created/changed file:
        watcher.Created += OncCreatedOrChanged;
        watcher.Changed += OncCreatedOrChanged;
        
        // Enable watching
        watcher.EnableRaisingEvents = true;

        Console.WriteLine("Monitoring file system changes. Press [Enter] to exit.");
        Console.ReadLine();
    }

    private static void OncCreatedOrChanged(object sender, FileSystemEventArgs e)
    {
        if (!File.Exists(e.FullPath)) return;
        var content = File.ReadAllText(e.FullPath);
        Console.WriteLine($"File content:\n{content}");
    }
}