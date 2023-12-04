using ProjectComp;

const int MAXNUM = 100;

Player[] myPlayers = new Player[MAXNUM];


// Utility instances for handling different functionalities

PlayerUtility playerUtility = new PlayerUtility(myPlayers);
DungeonUtility dungeonUtility = new DungeonUtility(myPlayers);


// Load initial data from files

playerUtility.GetAllPlayers();


bool exitProgram = false;
string menuSelection;

// Main program loop
while (!exitProgram)
{
    Console.Clear();
    PrintMenu();
    menuSelection = Console.ReadLine();

    if (menuSelection == "1")
    {
        playerUtility.AddPlayer();
    }
    else if (menuSelection == "2")
    {
        dungeonUtility.Explore();
    }
    else if (menuSelection == "3")
    {
        // Exit Program
        Console.Clear();
        Console.WriteLine("Exiting Program");
        exitProgram = true;
    }
    else
    {
        Console.WriteLine("Invalid selection, returning you to the menu.");
    }
}

static void PrintMenu()
{
    Console.WriteLine("Welcome to the Dungeon Adventure!");
    Console.WriteLine("1. Create Character");
    Console.WriteLine("2. Enter Dungeon");
    Console.WriteLine("3. Exit");
}
