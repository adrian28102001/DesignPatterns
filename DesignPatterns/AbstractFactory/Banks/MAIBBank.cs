namespace AbstractFactory.Banks;

public class MAIBBank : Bank
{
    public MoldovianBanks GetBankName()
    {
        return MoldovianBanks.MoldovaAgroinBank;
    }
}