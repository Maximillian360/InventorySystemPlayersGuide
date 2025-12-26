using Microsoft.VisualBasic.CompilerServices;

namespace InventorySystemPlayersGuide;

public class Pack
{
    public int MaximumItemCount { get; init; }
    public InventoryItem[] Items { get; set; }
    public float MaximumPackWeight { get; init; }
    public float MaximumPackVolume { get; init; }
    public float CurrentPackWeight { get; private set; }
    public float CurrentPackVolume { get; private set; }
    private int _itemCount = 0;

    public Pack(int maximumItemCount, float maximumPackWeight, float maximumPackVolume)
    {
        MaximumItemCount = maximumItemCount;
        MaximumPackWeight = maximumPackWeight;
        MaximumPackVolume = maximumPackVolume;
        CurrentPackWeight = 0;
        CurrentPackVolume = 0;
        Items = new InventoryItem[MaximumItemCount];
    }

    public bool Add(InventoryItem item)
    {
        if (Items.Length > MaximumItemCount)
        {
            Console.WriteLine($"ArrayExceededError! Cannot add more items in the Array! Current Item Count: {Items.Length}");
            return false;
        }
        
        if (item.Weight + CurrentPackWeight > MaximumPackWeight)
        {
            Console.WriteLine($"VolumeExceededError! Cannot add an item beyond Maximum Pack Volume! Weight: {item.Weight}, Max Weight: {MaximumPackWeight}");
            return false;
        }
        
        if (item.Volume + CurrentPackVolume > MaximumPackVolume)
        {
            Console.WriteLine($"VolumeExceededError! Cannot add an item beyond Maximum Pack Volume! Volume: {item.Volume}, Max Volume: {MaximumPackVolume}");
            return false;
        }
        
        Items[_itemCount] = item;
        _itemCount++;
        CurrentPackWeight += item.Weight;
        CurrentPackVolume += item.Volume;
        Console.WriteLine($"Item: {item.GetType().Name} added successfully!");
        Console.WriteLine($"Current Weight: {CurrentPackWeight} / {MaximumPackWeight}, Current Volume: {CurrentPackVolume} / {MaximumPackVolume}");
        return true;
    }

    public void PackItemCreator(out bool loopCheck)
    {
        int counter = _itemCount;
        loopCheck = true;
        while (loopCheck)
        {
            Console.WriteLine("Press the following number to add the item:");
            Console.WriteLine("1) Arrow, 2) Bow, 3) Sword, 4) Food, 5) Water, 6) Rope...");
            string userInput = "";
            userInput = Console.ReadLine();
            int? convertedUserInput = UserInputConverter(userInput);
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
            string loopInput = Console.ReadLine().ToLower();
            if (loopInput == "n")
            {
                Console.WriteLine("Exitting...");
                loopCheck = false;
                break;
            }
            ShowItemDetails();
        }
    }
    
    public void ShowItemDetails()
    {
        Console.Clear();
        Console.WriteLine($"Current Item Count: {_itemCount} / {MaximumItemCount}");
        Console.WriteLine($"Current Pack Weight: {CurrentPackWeight} / {MaximumPackWeight}");
        Console.WriteLine($"Current Pack Volume: {CurrentPackVolume} / {MaximumPackVolume}");
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i] == null) continue;
            Console.WriteLine("Current Items:");
            Console.WriteLine($"{i + 1}) Type: {Items[i].GetType().Name}, Weight: {Items[i].Weight}, Volume: {Items[i].Volume}");
        }
    }

    private int? UserInputConverter(string userInput)
    {
        while (true)
        {
            if (userInput == null || userInput == String.Empty)
            {
                Console.WriteLine("Input cannot be null or empty!: ");
                return null;
            }
            userInput = userInput.Trim();
            int number;
            if (!int.TryParse(userInput, out number))
            {
                Console.WriteLine("Input must be an integer!");
                return null;
            }
            if (number < 1 || number > 6)
            {
                Console.WriteLine("Input must be between 1 and 6!");
                return null;
            }
            return number;
        }
    }
    

    public static Pack SmallPack() => new Pack(10, 10.0f, 8.0f);
    public static Pack MediumPack() => new Pack(15, 15.0f, 12.0f);
    public static Pack LargePack() => new Pack(20, 20.0f, 15.0f);
}