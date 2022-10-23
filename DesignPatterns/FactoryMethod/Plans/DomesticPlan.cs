namespace FactoryMethod.Plans;

public class DomesticPlan : Plan
{
    public override void SetRate()
    {
        Rate = 5.50;
    }
}