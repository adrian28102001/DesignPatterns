namespace AbstractFactory.Loans;

public class HomeLoan : Loan
{
    public override void GetInterestRate(double rate)
    {
        Rate = rate;
    }
}