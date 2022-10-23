namespace AbstractFactory.Banks;

public class MobiasBank : Bank
{
    public MoldovianBanks GetBankName()
    {
        return MoldovianBanks.MobiasBank;
    }
}