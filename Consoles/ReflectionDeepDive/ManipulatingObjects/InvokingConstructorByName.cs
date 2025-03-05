using System.Reflection;

namespace ReflectionDeepDive.ManipulatingObjects;

public static class InvokingConstructorByName
{
    public static void Run()
    {
        Type type = typeof(Person);

        ConstructorInfo? constructorInfo = type.GetConstructor([typeof(string)]);

        object? obj = constructorInfo?.Invoke(["Alice"]);
        
        var person = (Person)obj!;
        person.Greet();
    }
}

internal class Person
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }

    public void Greet()
    {
        Console.WriteLine("Hello, my name is " + Name);
    }
}