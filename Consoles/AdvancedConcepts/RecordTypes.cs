namespace AdvancedConcepts;

public class RecordTypes
{
    public static void Run()
    {
        // Definition();
        WithKeyword();
    }

    private static void WithKeyword()
    {
        var student1 = new Student("Alice", 30);
        var student2 = student1 with { Age = 31 };

        Console.WriteLine(student1);
        Console.WriteLine(student2);
    }

    private static void Definition()
    {
        var person1 = new PersonClass { Name = "John" };
        var person2 = new PersonClass { Name = "John" };
        Console.WriteLine(person1 == person2);  // False (Different References)

        var record1 = new PersonRecord("John");
        var record2 = new PersonRecord("John");
        Console.WriteLine(record1 == record2); // True (Value-based equality)
    }
}

public record Student(string Name, int Age);

public class PersonClass
{
    public string Name { get; set; }
}

public record PersonRecord(string Name);

public record PersonRecord2
{
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public PersonRecord2()
    {
        Console.WriteLine("I'm a person");
    }
}