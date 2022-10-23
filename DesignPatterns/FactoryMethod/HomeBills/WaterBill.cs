namespace FactoryMethod.HomeBills;

public class WaterBill : Bill
{
    public override void SetPrice()
    {
        Price = 5;
    }
}