namespace FactoryMethod.Plans;

public abstract class Plan
{
    protected double Rate;

    public abstract void SetRate();

    public void CalculateBill(int units)
    {
        Console.WriteLine(units * Rate);
    }
}