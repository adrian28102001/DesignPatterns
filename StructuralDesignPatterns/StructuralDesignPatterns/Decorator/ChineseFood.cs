namespace StructuralDesignPatterns.Decorator;

public class ChineseFood : FoodDecorator
{
    private IFood NewFood { get; }
    public ChineseFood(IFood newFood) : base(newFood)
    {
        NewFood = newFood;
    }
    
    public new string PrepareFood()
    {
        return NewFood.PrepareFood() + "ChineseFood";
    }

    public new double FoodPrice()
    {
        return NewFood.FoodPrice() + 250;
    }
}