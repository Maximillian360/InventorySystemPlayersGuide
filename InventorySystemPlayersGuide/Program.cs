// See https://aka.ms/new-console-template for more information

using InventorySystemPlayersGuide;

bool loopCheck = true;
while (loopCheck)
{
    Console.WriteLine("Press 1) Small Pack, 2) Medium Pack, 3) Large Pack");
    int userNumber = InputCheck();
    if (userNumber == 1)
    {
        var pack = Pack.SmallPack();
        pack.ShowItemDetails();
        pack.PackItemCreator(out loopCheck);
    }
    if (userNumber == 2)
    {
        var pack = Pack.MediumPack();
        pack.ShowItemDetails();
        pack.PackItemCreator(out loopCheck);
    }
    if (userNumber == 3)
    {
        var pack = Pack.LargePack();
        pack.ShowItemDetails();
        pack.PackItemCreator(out loopCheck);
    }
}


static int InputCheck()
{
    while (true)
    {
        string initialUserInput = Console.ReadLine();
        int userNumber;
        if (string.IsNullOrEmpty(initialUserInput))
        {
            Console.WriteLine("Input cannot be empty!");
            continue;
        }

        if (!int.TryParse(initialUserInput, out userNumber))
        {
            Console.WriteLine("Input must be an integer!");
            continue;
        }

        if (userNumber < 1 || userNumber > 3)
        {
            Console.WriteLine("Input must be between 1 and 3");
            continue;
        } 
        return userNumber;
    }
}
