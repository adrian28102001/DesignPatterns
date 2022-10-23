using Builder.Packing;

namespace Builder.Items;

public interface ITem
{
    public string Name();
    public IPacking Packing();
    public float Price();	
}