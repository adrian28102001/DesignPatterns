namespace FactoryMethod.HomeBills;

public class LightBill : Bill
{
    public override void SetPrice()
    {
        Price = 10;
    }
}