namespace InventorySystemPlayersGuide;

public class Sword : InventoryItem
{
    private static float swordWeight = 5;
    private static float swordVolume = 3;
    public override string ToString()
    {
        return GetType().Name;
    }
    public Sword() : base(swordWeight, swordVolume)
    {
        
    }
}