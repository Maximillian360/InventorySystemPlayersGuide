namespace InventorySystemPlayersGuide;

public class InventoryItem
{
    public float Weight  { get; set; }
    public float Volume { get; set; }

    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}