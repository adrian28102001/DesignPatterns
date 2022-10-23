using AbstractFactory.Banks;
using AbstractFactory.Loans;

namespace AbstractFactory.Factory;

public abstract class AbstractFactory
{
    public abstract Bank GetBank(MoldovianBanks bank);  
    public abstract Loan GetLoan(LoansPurposes loan);  
}