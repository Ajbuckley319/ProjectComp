using System;
using System.IO;
namespace ProjectComp
{

    public class PlayerUtility
    {
        private Player[] myPlayers;

        public PlayerUtility(Player[] myPlayers)
        {
            this.myPlayers = myPlayers;
        }

        public void GetAllPlayers()
        {
            Player.SetCount(0);

            StreamReader inFile = new StreamReader("player-data.txt");

            string line = inFile.ReadLine();
            while (line != null)
            {
                string[] temp = line.Split('#');

                myPlayers[Player.GetCount()] = new Player(temp[1]);

                Player.IncCount();

                line = inFile.ReadLine();
            }

            inFile.Close();
        }

        public void SavePlayers(Player[] myPlayers)
        {
            StreamWriter outFile = new StreamWriter("player-data.txt");

            for (int i = 0; i < Player.GetCount(); i++)
            {
                outFile.WriteLine(myPlayers[i].ToFile());
            }

            outFile.Close();
        }

        public void AddPlayer()
        {
            Console.WriteLine("Please enter the player name:");
            string playerName = Console.ReadLine();

            myPlayers[Player.GetCount()] = new Player(playerName);
            Player.IncCount();

            SavePlayers(myPlayers);
        }

        public void RemovePlayer()
        {
            Console.WriteLine(Player.GetCount());
            for (int i = 0; i < Player.GetCount(); i++)
            {
                Console.WriteLine(myPlayers[i].GetPlayerName());
            }

            Console.WriteLine("Enter the player name that you would like to remove.");
            string searchVal = Console.ReadLine();
            int deleteIndex = FindPlayer(searchVal);

            Console.WriteLine(deleteIndex);

            SavePlayers(myPlayers, deleteIndex);
        }

        private int FindPlayer(string searchVal)
        {
            for (int i = 0; i < Player.GetCount(); i++)
            {
                if (myPlayers[i].GetPlayerName().ToUpper() == searchVal.ToUpper())
                {
                    return i;
                }
            }
            return -1;
        }

        public void SavePlayers(Player[] myPlayers, int deleteIndex)
        {

            StreamWriter outFile = new StreamWriter("player-data.txt");

            for (int i = 0; i < Player.GetCount(); i++)
            {
                if (deleteIndex != i)
                {
                    outFile.WriteLine(myPlayers[i].ToFile());
                }
            }

            outFile.Close();
        }
    }
}

