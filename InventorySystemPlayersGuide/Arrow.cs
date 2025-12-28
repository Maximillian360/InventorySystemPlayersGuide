namespace InventorySystemPlayersGuide;

public class Arrow : InventoryItem
{
    private static float arrowWeight = 0.1f;
    private static float arrowVolume = 0.05f;

    public override string ToString()
    {
        return GetType().Name;
    }

    public Arrow() : base(arrowWeight, arrowVolume)
    { }
}