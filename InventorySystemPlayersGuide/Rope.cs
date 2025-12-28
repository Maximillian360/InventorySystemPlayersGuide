namespace InventorySystemPlayersGuide;

public class Rope : InventoryItem
{
    private static float ropeWeight = 1;
    private static float ropeVolume = 0.5f;
    public override string ToString()
    {
        return GetType().Name;
    }
    public Rope() : base(ropeWeight, ropeVolume)
    {
        
    }
}