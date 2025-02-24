namespace Events_Delegates_Action_Func;

public static class Funcs
{
    public static void Run()
    {
        var order = new FoodDelivery();
        
        // Define a Func delegate:
        Func<double, double, double, double> calculateTotal = order.CalculateTotal;
        
        // Invoke the Func delegate:
        var total = calculateTotal(10.99, 2.99, 1.50);
        Console.WriteLine($"Total: {total}");
    }
}

class FoodDelivery
{
    public double CalculateTotal(double foodPrice, double deliveryFee, double discount)
    {
        return foodPrice + deliveryFee - discount;
    }
}