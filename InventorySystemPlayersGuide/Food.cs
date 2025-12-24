namespace InventorySystemPlayersGuide;

public class Food : InventoryItem
{
    private static float foodWeight = 1;
    private static float foodVolume = 0.5f;

    public Food() : base(foodWeight, foodVolume)
    {
        
    }
}