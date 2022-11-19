namespace StructuralDesignPatterns.Adapter;

public class BankCustomer : BankDetails, ICreditCard
{
    private const string _bankName = "VictoriaBank";
    private const string _accountHolderName = "Adrian";
    private const long _accountNumber = 123;


    public void GiveBankDetails()
    {
        SetBankDetails(_bankName, _accountHolderName, _accountNumber);
    }

    public string GetCreditCard()
    {
        var bankName = GetBankName();
        var accountHolderName = GetAccountHolderName();
        var accountNumber = GetAccountNumber();

        return $"Bank {bankName} has a user with name {accountHolderName} and accountNumber {accountNumber}";
    }
}