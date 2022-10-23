namespace Builder;

public class Program
{
    public static void Main(string[] args)
    {
        var mealBuilder = new MealBuilder();

        var vegMeal = mealBuilder.PrepareVegMeal();
        Console.WriteLine("Veg Meal");
        vegMeal.showItems();
        Console.WriteLine("Total Cost: " + vegMeal.GetCost());

        var nonVegMeal = mealBuilder.PrepareNonVegMeal();
        Console.WriteLine("Non-Veg Meal");
        nonVegMeal.showItems();
        Console.WriteLine("Total Cost: " + nonVegMeal.GetCost());
    }
}