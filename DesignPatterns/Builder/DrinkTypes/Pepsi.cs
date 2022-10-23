using Builder.Items;

namespace Builder.Drinktypes;

public class Pepsi : ColdDrink
{
    public override float Price() {
        return 20.0f;
    }

    public override string Name() {
        return "Pepsi";
    }
}