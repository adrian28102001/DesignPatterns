namespace StructuralDesignPatterns.Decorator;

public abstract class FoodDecorator : IFood
{
    private readonly IFood _newFood;

    protected FoodDecorator(IFood newFood)
    {
        _newFood = newFood;
    }

    public string PrepareFood()
    {
        return _newFood.PrepareFood();
    }

    public double FoodPrice()
    {
        return _newFood.FoodPrice();
    }
}