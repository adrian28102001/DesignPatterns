namespace FactoryMethod.Plans;

public class CommercialPlan : Plan
{
    public override void SetRate()
    {
        Rate = 7.50;
    }
}