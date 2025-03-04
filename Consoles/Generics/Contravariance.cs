namespace Generics;

public static class Contravariance
{
    public static void Run()
    {
        Example1();
    }

    private static void Example1()
    {
        IContravariance<Dog> dogProcessor = new AnimalProcessor();
        dogProcessor.Process(new Dog()); // Dog is treated as an Animal
    }
}

internal interface IContravariance<in T>
{
    void Process(T item);
}

internal class AnimalProcessor : IContravariance<Animal>
{
    public void Process(Animal item)
    {
        Console.WriteLine("Processing an animal.");
    }
}