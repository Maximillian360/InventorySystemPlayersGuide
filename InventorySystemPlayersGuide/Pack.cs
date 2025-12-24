namespace InventorySystemPlayersGuide;

public class Pack
{
    public int MaximumItemCount { get; init; }
    public InventoryItem[] Items { get; set; }
    public float MaximumPackWeight { get; init; }
    public float MaximumPackVolume { get; init; }
    private int _itemCount = 0;

    public Pack(int maximumItemCount, float maximumPackWeight, float maximumPackVolume)
    {
        MaximumItemCount = maximumItemCount;
        MaximumPackWeight = maximumPackWeight;
        MaximumPackVolume = maximumPackVolume;
        Items = new InventoryItem[MaximumItemCount];
    }

    public bool Add(InventoryItem item)
    {
        if (Items.Length > MaximumItemCount)
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

    public void ShowItemDetails()
    {
        Console.WriteLine($"Maximum Item Count: {MaximumItemCount}");
        Console.WriteLine($"Maximum Pack Weight: {MaximumPackWeight}");
        Console.WriteLine($"Maximum Pack Volume: {MaximumPackVolume}");
        for (int i = 0; i < Items.Length; i++)
        {
            Console.WriteLine($"{i + 1}). Type: {Items[i].GetType().Name} Weight: {Items[i].Weight}, Volume: {Items[i].Volume}");
        }
    }

    public static Pack SmallPack() => new Pack(10, 10.0f, 8.0f);
    public static Pack MediumPack() => new Pack(15, 15.0f, 12.0f);
    public static Pack LargePack() => new Pack(20, 20.0f, 15.0f);
}