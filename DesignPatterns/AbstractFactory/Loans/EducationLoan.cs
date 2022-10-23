namespace AbstractFactory.Loans;

public class EducationLoan : Loan
{
    public override void GetInterestRate(double rate)
    {
        Rate = rate;
    }
}