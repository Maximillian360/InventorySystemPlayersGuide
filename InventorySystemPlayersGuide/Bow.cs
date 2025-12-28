namespace InventorySystemPlayersGuide;

public class Bow : InventoryItem
{
    private static float bowWeight = 1;
    private static float bowVolume = 4;
    public override string ToString()
    {
        return GetType().Name;
    }
    public Bow() : base(bowWeight, bowVolume)
    { }
}