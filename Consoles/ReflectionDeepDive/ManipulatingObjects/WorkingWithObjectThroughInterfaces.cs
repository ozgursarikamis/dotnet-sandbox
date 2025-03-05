namespace ReflectionDeepDive.ManipulatingObjects;

public static class WorkingWithObjectThroughInterfaces
{
    public static void Run()
    {
        Type type = typeof(FriendlyPerson);

        IGreetable instance = (IGreetable)Activator.CreateInstance(type, "Bob");
        
        // Now we can use instance.Greet(); without knowing the concrete class.
        instance.Greet();
    }
}

internal interface IGreetable { void Greet(); }

internal class FriendlyPerson : IGreetable
{
    private string name;

    public FriendlyPerson(string name)
    {
        this.name = name;
    }
    
    public void Greet()
    {
        Console.WriteLine($"Hello I'm {name} and I love coding!");
    }
}