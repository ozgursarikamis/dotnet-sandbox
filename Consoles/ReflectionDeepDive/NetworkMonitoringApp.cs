using System.Reflection;

namespace ReflectionDeepDive;

public class NetworkMonitoringApp
{
    public static void Run()
    {
        Console.WriteLine("🔍 Searching for monitoring tasks...");

        var monitorTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type => typeof(INetworkMonitor).IsAssignableFrom(type) &&
                           type is { IsInterface: false, IsAbstract: false })
            .ToList();
        
        Console.WriteLine($"📌 Found {monitorTypes.Count} monitoring tasks.\n");

        foreach (var monitorType in monitorTypes)
        {
            // Create instance dynamically:
            var monitor = (INetworkMonitor)Activator.CreateInstance(monitorType)!;

            Console.WriteLine();
            Console.WriteLine($"▶ Running {monitorType.Name}...");
            monitor.RunCheck();
            Console.WriteLine();
        }
    }
}

internal interface INetworkMonitor
{
    void RunCheck();
}

internal class PingCheck : INetworkMonitor
{
    public void RunCheck()
    {
        Console.WriteLine("✅ PingCheck: Network is reachable.");
    }
}

internal class DnsCheck : INetworkMonitor
{
    public void RunCheck()
    {
        Console.WriteLine("✅ DNSCheck: DNS resolution is working.");
    }
}

internal class FirewallCheck : INetworkMonitor
{
    public void RunCheck()
    {
        Console.WriteLine("✅ FirewallCheck: No unexpected blocked connections.");
    }
}