namespace InventorySystemPlayersGuide;

public class Sword : InventoryItem
{
    private static float swordWeight = 5;
    private static float swordVolume = 3;

    public Sword() : base(swordWeight, swordVolume)
    {
        
    }
}