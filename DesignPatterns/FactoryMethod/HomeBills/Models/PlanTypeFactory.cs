namespace FactoryMethod.HomeBills.Models;

public class PlanTypeFactory
{
    public Bill GetBillType(BillType planType)
    {
        return planType switch
        {
            BillType.Gas => new GasBill(),
            BillType.Light => new LightBill(),
            BillType.Water => new WaterBill(),
            _ => null!
        };
    }
}