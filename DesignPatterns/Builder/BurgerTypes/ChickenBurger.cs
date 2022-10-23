using Builder.Items;

namespace Builder.BurgerTypes;

public class ChickenBurger : Burger
{
    public override float Price() {
        return 25.0f;
    }
    
    public override string Name() {
        return "Veg Burger";
    }
}