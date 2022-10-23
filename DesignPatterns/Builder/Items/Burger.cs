using Builder.Packing;

namespace Builder.Items;

public abstract class Burger : ITem
{
    public virtual string Name()
    {
        throw new NotImplementedException();
    }

    public IPacking Packing()
    {
        return new Wrapper();
    }

    public virtual float Price()
    {
        throw new NotImplementedException();
    }
}