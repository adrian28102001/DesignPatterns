namespace AbstractFactory.Loans;

public abstract class Loan
{
    protected double Rate;
    public abstract void GetInterestRate(double rate);

    public void CalculateLoanPayment(double loanAmount, int years)
    {
        var n = years * 12;
        Rate /= 1200;
        var emi = Rate * Math.Pow(1 + Rate, n) / (Math.Pow(1 + Rate, n) - 1) * loanAmount;

        Console.Write("Your monthly EMI is " + emi + " for the amount " + loanAmount + " you have borrowed");
    }
}