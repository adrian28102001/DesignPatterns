using Builder.Items;

namespace Builder;

public class Meal
{
    private List<ITem> items = new List<ITem>();

    public float GetCost()
    {
        return items.Sum(item => item.Price());
    }
    
    public void showItems(){

        foreach (var item in items)
        {
            Console.Write("Item : " + item.Name());
            Console.Write(", Packing : " + item.Packing().Pack());
            Console.WriteLine(", Price : " + item.Price());
        }
        
    }

    public void AddItem(ITem item)
    {
        items.Add(item);
    }
}