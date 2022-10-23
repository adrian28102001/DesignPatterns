namespace AbstractFactory.Loans;

public class BusinessLoan : Loan
{
    public override void GetInterestRate(double rate)
    {
        Rate = rate;
    }
}