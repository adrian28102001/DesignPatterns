namespace StructuralDesignPatterns.Facade;

public class Samsung : IMobileShop
{
    public void ModelNo()
    {
        Console.WriteLine(" S22 Ultra ");  
    }

    public void Price()
    {
        Console.WriteLine("10000 lei");  

    }
}