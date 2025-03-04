namespace AdvancedConcepts.PatternMatching;

public class PropertyMatching
{
    public static void Run()
    {
        var car1 = new Car { Brand = "Tesla", Year = 2021 };
        var car2 = new Car { Brand = "Tesla", Year = 2019 };
        var car3 = new Car { Brand = "Tesla" };
        var car4 = new Car { Brand = "Toyota", Year = 1999 };
        var car5 = new Car { Brand = "Unknown" };

        Console.WriteLine(DescribeCar(car1));
        Console.WriteLine(DescribeCar(car2));
        Console.WriteLine(DescribeCar(car3));
        Console.WriteLine(DescribeCar(car4));
        Console.WriteLine(DescribeCar(car5));
    }

    private static string DescribeCar(Car car) => car switch
    {
        { Brand: "Tesla", Year: > 2020 } => "New Tesla",
        { Brand: "Tesla", Year: < 2020 } => "Old Tesla",
        { Brand: "Tesla" } => "Tesla",
        { Year: < 2000 } => "Classic car",
        _ => "Unknown car"
    };
}

class Car
{
    public string Brand { get; set; }
    public int Year { get; set; }
}