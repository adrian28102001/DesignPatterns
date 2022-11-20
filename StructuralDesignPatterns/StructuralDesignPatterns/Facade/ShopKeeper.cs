namespace StructuralDesignPatterns.Facade;

public class ShopKeeper
{
    private IMobileShop Iphone;
    private IMobileShop Samsung;

    public ShopKeeper()
    {
        Iphone = new Iphone();
        Samsung = new Samsung();
    }

    public void IphoneSale()
    {
        Iphone.ModelNo();
        Iphone.Price();
    }
    public void SamsungSale()
    {
        Samsung.ModelNo();
        Samsung.Price();
    }
}