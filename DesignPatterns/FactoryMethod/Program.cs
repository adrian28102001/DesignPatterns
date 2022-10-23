using FactoryMethod.HomeBills.Models;

namespace FactoryMethod;

public class Program
{
    public static void Main(string[] args)
    {
        const int volume = 20;
        const BillType billType = BillType.Light;
        var billFactory = new PlanTypeFactory();
        var bill = billFactory.GetBillType(billType);

        Console.WriteLine($"Bill amount for {billType} for volume: {volume} is: ");
        bill.SetPrice();
        bill.CalculateBill(volume);
    }
}