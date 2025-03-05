namespace Generics;

public class CovarianceFoodProvider
{
    public static void Run()
    {
        IFoodProvider<Pizza> pizzaShop = new PizzaProvider();
        
        // Covariance allows us to do this:
        IFoodProvider<Food> foodShop = pizzaShop;

        Food myFood = foodShop.GetFood(); // returns Pizza but treated as Food.
        Console.WriteLine($"Received food: {myFood.GetType().Name}");
    }
}

internal class Food {}
internal class Pizza : Food {}
internal class Sushi : Food {}

// The out keyword makes it covariant
// → meaning a more derived type (Pizza) can be assigned to a base type (Food).
internal interface IFoodProvider<out T>
{
    T GetFood();
}

internal class PizzaProvider : IFoodProvider<Pizza>
{
    public Pizza GetFood() => new Pizza();
}