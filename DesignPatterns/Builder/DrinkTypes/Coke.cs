using Builder.Items;

namespace Builder.Drinktypes;

public class Coke : ColdDrink
{
    public override float Price()
    {
        return 20.0f;
    }

    public override string Name()
    {
        return "Coke";
    }
}