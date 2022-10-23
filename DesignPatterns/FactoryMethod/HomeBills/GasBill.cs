namespace FactoryMethod.HomeBills;

public class GasBill : Bill
{
    public override void SetPrice()
    {
        Price = 20;
    }
}