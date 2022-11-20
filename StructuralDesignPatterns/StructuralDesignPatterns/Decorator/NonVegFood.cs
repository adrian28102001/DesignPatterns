namespace StructuralDesignPatterns.Decorator;

public class NonVegFood : FoodDecorator
{
    private IFood NewFood { get; }

    public NonVegFood(IFood newFood) : base(newFood)
    {
        NewFood = newFood;
    }

    public new string PrepareFood()
    {
        return NewFood.PrepareFood() + "NonVegFood";
    }

    public new double FoodPrice()
    {
        return NewFood.FoodPrice() + 150;
    }
}