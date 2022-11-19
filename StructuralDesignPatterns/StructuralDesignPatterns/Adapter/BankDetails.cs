namespace StructuralDesignPatterns.Adapter;

public class BankDetails
{
    private string BankName { get; set; }
    private string AccountHolderName { get; set; }
    private long AccountNumber { get; set; }


    protected string GetBankName()
    {
        return BankName;
    }

    protected string GetAccountHolderName()
    {
        return AccountHolderName;
    }

    protected long GetAccountNumber()
    {
        return AccountNumber;
    }

    protected void SetBankDetails(string bankName, string accountHolderName, long accountNumber)
    {
        BankName = bankName;
        AccountHolderName = accountHolderName;
        AccountNumber = accountNumber;
    }
}