namespace AbstractFactory.Banks;

public class VictoriaBank : Bank
{
    public MoldovianBanks GetBankName()
    {
        return MoldovianBanks.VictoriaBank;
    }
}