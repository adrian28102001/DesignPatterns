using AbstractFactory.Banks;
using AbstractFactory.Factory;
using AbstractFactory.Loans;

namespace AbstractFactory;

public class Program
{
    public static void Main(string[] args)
    {
        const MoldovianBanks bankName = MoldovianBanks.VictoriaBank;

        var bankFactory = FactoryCreator.GetFactory(FactoryType.Bank);
        var bank = bankFactory.GetBank(bankName);

        Console.WriteLine("At: " + bank.GetBankName() + ": ");

        const LoansPurposes loanName = LoansPurposes.Business;
        const int loadAmount = 1000;
        const int years = 5;

        var loanFactory = FactoryCreator.GetFactory(FactoryType.Loan);
        var loan = loanFactory.GetLoan(loanName);
        loan.GetInterestRate(12);
        loan.CalculateLoanPayment(loadAmount, years);
    }
}