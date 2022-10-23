namespace FactoryMethod.Plans;

public class InstitutionalPlan : Plan
{
    public override void SetRate()
    {
        Rate = 3.50;
    }
}