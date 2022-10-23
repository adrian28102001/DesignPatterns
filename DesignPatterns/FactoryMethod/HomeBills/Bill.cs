namespace FactoryMethod.HomeBills;

public abstract class Bill
{
    protected double Price;
    
    public abstract void SetPrice();

    public void CalculateBill(int volume)
    {
        Console.WriteLine(volume * Price);
    }
}