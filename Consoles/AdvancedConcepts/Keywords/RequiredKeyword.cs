namespace AdvancedConcepts.Keywords;

public class RequiredKeyword
{
    public static void Run()
    {
        var person = new Person
        {
            Name = "John",
            Age = 20
        };
        Console.WriteLine($"{person.Name}, {person.Age}");

        var person2 = new Person2
        {
            Name = "John",
        };
        Console.WriteLine(person2);
    }
}

class Person
{
    public required string Name { get; set; }
    public required int Age { get; set; }
}

record Person2
{
    public required string Name { get; set; }
    public int Age { get; set; }
}