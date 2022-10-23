using AbstractFactory.Banks;
using AbstractFactory.Loans;

namespace AbstractFactory.Factory;

public class LoanFactory : AbstractFactory
{
    public override Bank GetBank(MoldovianBanks bank)
    {
        return null!;
    }

    public override Loan GetLoan(LoansPurposes loan)
    {
        return loan switch
        {
            LoansPurposes.Home=> new HomeLoan(),
            LoansPurposes.Business=> new BusinessLoan(),
            LoansPurposes.Education=> new EducationLoan(),
            _ => null!
        };
    }
}