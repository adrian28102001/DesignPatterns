namespace StructuralDesignPatterns.Facade;

public class Iphone : IMobileShop
{
    public void ModelNo()
    {
        Console.WriteLine(" Iphone 6 ");  
    }

    public void Price()
    {
        Console.WriteLine("10000 lei");  

    }
}