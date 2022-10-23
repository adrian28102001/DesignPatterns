namespace FactoryMethod.Plans;

public class GetPlanFactory
{
    public Plan GetPlan(PlanType planType)
    {
        return planType switch
        {
            PlanType.Commercial => new CommercialPlan(),
            PlanType.Domestic => new DomesticPlan(),
            PlanType.Institutional => new InstitutionalPlan(),
            _ => null!
        };
    }
}