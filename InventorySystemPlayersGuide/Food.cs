namespace InventorySystemPlayersGuide;

public class Food : InventoryItem
{
    private static float foodWeight = 1;
    private static float foodVolume = 0.5f;
    public override string ToString()
    {
        return GetType().Name;
    }
    public Food() : base(foodWeight, foodVolume)
    {
        
    }
}