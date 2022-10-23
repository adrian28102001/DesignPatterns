using AbstractFactory.Banks;
using AbstractFactory.Loans;

namespace AbstractFactory.Factory;

public class BankFactory : AbstractFactory
{
    public override Bank GetBank(MoldovianBanks bank)
    {
        return bank switch
        {
            MoldovianBanks.MobiasBank => new MobiasBank(),
            MoldovianBanks.VictoriaBank => new VictoriaBank(),
            MoldovianBanks.MoldovaAgroinBank => new MAIBBank(),
            _ => null!
        };
    }


    public override Loan GetLoan(LoansPurposes loan)
    {
        return null!;
    }
}