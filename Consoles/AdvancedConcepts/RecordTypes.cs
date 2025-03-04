namespace AdvancedConcepts;

public class RecordTypes
{
    public static void Run()
    {
        Definition();
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