namespace InventorySystemPlayersGuide;

public class Water : InventoryItem
{
    private static float waterWeight = 2;
    private static float waterVolume = 3;

    public Water() : base(waterWeight, waterVolume)
    {
        
    }
}