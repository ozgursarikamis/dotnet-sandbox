using System.Collections.Concurrent;

namespace FilesAndStreams.MonitoringFileSystemChanges;

public static class IgnoringDuplicateEvents
{
    public static void Run()
    {
        
        const string path = "WatchedFolder";
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        var watcher = new FileSystemWatcher(path);

        watcher.Changed += OnCreatedOrChanged;
        watcher.Created += OnCreatedOrChanged;
    }

    private static ConcurrentDictionary<string, DateTime> fileEvents = new();

    private static void OnCreatedOrChanged(object sender, FileSystemEventArgs e)
    {
        var now = DateTime.Now;

        var fileFullPath = e.FullPath;
        if (fileEvents.TryGetValue(fileFullPath, out var lastEvent) && (now - lastEvent).TotalMilliseconds < 500)
            return;
        
        fileEvents[fileFullPath] = now;
        if (!File.Exists(fileFullPath)) return;
        
        var content = File.ReadAllText(fileFullPath);
        Console.WriteLine($"File content:\n{content}");
    }
}