namespace Events_Delegates_Action_Func;

public class FuncWithLinq
{
    public static void Run()
    {
        var employees = new List<Employee>
        {
            new() { Name = "Alice", Salary = 40000 },
            new() { Name = "Bob", Salary = 60000 },
            new() { Name = "Charlie", Salary = 75000 }
        };
        
        // Func<T, bool> used in Where() to filter employees:
        Func<Employee, bool> highEarner = e => e.Salary > 50_000;
        var filtered = employees.Where(highEarner);
        
        foreach (var employee in filtered)
        {
            Console.WriteLine($"{employee.Name} earns {employee.Salary}");
        }
    }
}

public class Employee
{
    public string? Name { get; set; }
    public double? Salary { get; set; }
}