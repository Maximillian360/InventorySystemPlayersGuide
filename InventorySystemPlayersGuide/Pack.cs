namespace InventorySystemPlayersGuide;

public class Pack
{
    public int TotalItem { get; init; }
    public InventoryItem[] Items { get; set; }
    public float MaximumPackWeight { get; init; }
    public float MaximumPackVolume { get; init; }
    private int _itemCount = 0;

    public Pack(int totalItem, float maximumPackWeight, float maximumPackVolume, InventoryItem[] Item = null)
    {
        TotalItem = totalItem;
        MaximumPackWeight = maximumPackWeight;
        MaximumPackVolume = maximumPackVolume;
        Items = new InventoryItem[TotalItem];
    }

    public bool Add(InventoryItem item)
    {
        if (Items.Length > TotalItem)
        {
            Console.WriteLine($"ArrayExceededError! Cannot add more items in the Array! Current Item Count: {Items.Length}");
            return false;
        }
        
        if (item.Weight > MaximumPackWeight)
        {
            Console.WriteLine($"VolumeExceededError! Cannot add an item beyond Maximum Pack Volume! Weight: {item.Weight}, Max Weight: {MaximumPackWeight}");
            return false;
        }

        if (item.Volume > MaximumPackVolume)
        {
            Console.WriteLine($"VolumeExceededError! Cannot add an item beyond Maximum Pack Volume! Volume: {item.Volume}, Max Volume: {MaximumPackVolume}");
            return false;
        }
        
        Items[_itemCount] = item;
        _itemCount++;
        Console.WriteLine("Item added successfully!");
        return true;
    }
}