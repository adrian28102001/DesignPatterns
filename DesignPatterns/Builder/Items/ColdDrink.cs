using Builder.Packing;

namespace Builder.Items;

public abstract class ColdDrink : ITem
{
    public virtual string Name()
    {
        throw new NotImplementedException();
    }

    public IPacking Packing()
    {
        return new Bottle();
    }

    public virtual float Price()
    {
        throw new NotImplementedException();
    }
}