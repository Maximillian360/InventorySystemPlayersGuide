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

    public void PackItemCreator(Pack itemPack)
    {
        int counter = _itemCount;
        bool addItemstoPackCheck = true;
        while (addItemstoPackCheck)
        {
            Console.WriteLine("Adding Item...");
            Console.WriteLine("1) Arrow, 2) Bow, 3) Sword, 4) Food, 5) Water, 6) Rope...");
            string userInput = "";
            userInput = Console.ReadLine();
            int convertedUserInput = UserInputConverter(userInput);
            switch (convertedUserInput)
            {
                case 1:
                    Add(new Arrow());
                    counter++;
                    break;
                case 2:
                    Add(new Bow());
                    counter++;
                    break;
                case 3:
                    Add(new Sword());
                    counter++;
                    break;
                case 4:
                    Add(new Food());
                    counter++;
                    break;
                case 5:
                    Add(new Water());
                    counter++;
                    break;
                case 6:
                    Add(new Rope());
                    counter++;
                    break;
                default:
                    Console.WriteLine("Invalid Converted Input!");
                    break;
            }
            Console.WriteLine("Would you like to add another item? Y: Yes, N: No");
            string loopInput = Console.ReadLine();
            if (loopInput == "N") addItemstoPackCheck = false;
        }
    }

    private int UserInputConverter(string userInput)
    {
        while (true)
        {
            if (userInput == null || userInput == String.Empty)
            {
                Console.WriteLine("Input cannot be null or empty!: ");
                continue;
            }
            userInput = userInput.Trim();
            int number;
            if (!int.TryParse(userInput, out number))
            {
                Console.WriteLine("Input must be an integer!");
                continue;
            }

            if (number < 1 || number > 6)
            {
                Console.WriteLine("Input must be between 1 and 6!");
                continue;
            }
            return number;
        }
    }
    

    public static Pack SmallPack() => new Pack(10, 10.0f, 8.0f);
    public static Pack MediumPack() => new Pack(15, 15.0f, 12.0f);
    public static Pack LargePack() => new Pack(20, 20.0f, 15.0f);
}