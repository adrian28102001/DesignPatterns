namespace StructuralDesignPatterns.Decorator;

public class VegFood : IFood
{
    public string PrepareFood()
    {
        return "Veg Food";  
    }

    public double FoodPrice()
    {
        return 50;
    }
}