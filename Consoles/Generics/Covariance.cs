namespace Generics;

public static class Covariance
{
    public static void Run()
    {
        CovarianceExample();
    }

    private static void CovarianceExample()
    {
        ICovariant<Animal> animals = new DogShelter();
        var myAnimal = animals.GetItem(); // returns a dog, but treated as Animal.
        myAnimal.Walk();
    }
}

class Animal
{
    public void Walk()
    {
        Console.WriteLine("The animal is walking!");
    }
}
class Dog: Animal {}
class Cat : Animal {}

internal interface ICovariant<out T>
{
    T GetItem();
}

internal class DogShelter: ICovariant<Dog>
{
    public Dog GetItem() => new Dog();
}