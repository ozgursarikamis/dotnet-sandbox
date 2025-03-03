namespace LazyClass;

public class BasicSample
{
    private Lazy<List<string>> _reports = new(() =>
    {
        Console.WriteLine("Generating Report...");
        return GenerateReport();
    });

    public List<string> ReportData => _reports.Value;

    private static List<string> GenerateReport()
    {
        // Simulate a heavy computation
        return ["Data1", "Data2", "Data3"];
    }
}