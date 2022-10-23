namespace AbstractFactory.Factory;

public class FactoryCreator
{
    public static AbstractFactory GetFactory(FactoryType choice)
    {
        return choice switch
        {
            FactoryType.Bank => new BankFactory(),
            FactoryType.Loan => new LoanFactory(),
            _ => null!
        };
    }
}