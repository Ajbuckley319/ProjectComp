using System;
using System.Threading;

namespace ProjectComp
{
    public class DungeonUtility
    {
        private Player[] myPlayers;
        private int currentPlayerIndex;
        private int lives;

        public DungeonUtility(Player[] myPlayers)
        {
            this.myPlayers = myPlayers;
            this.currentPlayerIndex = 0; // Assuming you want to start with the first player in the array
            this.lives = 3;
        }

        public void Explore()
        {
            Console.Clear();
            Console.WriteLine($"Welcome, {myPlayers[currentPlayerIndex].playerName}, to the treacherous dungeon!");

            // Simulate exploring the dungeon
            SimulateDungeonExploration();

            Console.WriteLine("Dungeon exploration completed!");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void SimulateDungeonExploration()
        {
            // Simulate encountering an enemy
            Console.WriteLine("Uh-oh! You've stumbled across a fierce enemy!");

            // Start the word typing game
            string[] wordsToType = GenerateRandomWords().Split();
            for (int i = 0; i < wordsToType.Length; i++)
            {
                Console.WriteLine($"\nWord {i + 1}: Type the following word within 30 seconds:");

                // Display target word
                Console.WriteLine(wordsToType[i]);

                // Start the timer
                bool success = TypeWordsWithinTimeLimit(wordsToType[i], 30);

                if (!success)
                {
                    lives--;
                    Console.WriteLine($"You failed to type the word in time. Lives remaining: {lives}");

                    if (lives == 0)
                    {
                        Console.WriteLine("You ran out of lives. Game over!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Congratulations! You typed the word correctly!");
                }
            }

            Console.WriteLine("Congratulations! You defeated the enemy!");
        }


        private string GenerateRandomWords()
        {
            // For simplicity, generate a random string of words
            string[] words = { "dragon", "treasure", "wizard", "sword", "adventure", "courage", "shield", "magical", "enchant", "dungeon" };
            Random random = new Random();

            // Select 10 random words
            string targetWords = string.Join(" ", words.OrderBy(_ => random.Next()).Take(10));
            return targetWords;
        }

        private bool TypeWordsWithinTimeLimit(string targetWords, int timeLimitSeconds)
        {
            Console.Write("Type here: ");
            string userInput = Console.ReadLine();

            // Use a stopwatch to measure the time elapsed
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            // Keep reading user input until they press Enter or time runs out
            while (true)
            {
                if (stopwatch.Elapsed.TotalSeconds >= timeLimitSeconds || userInput == targetWords)
                {
                    stopwatch.Stop();
                    return userInput == targetWords;
                }

                if (Console.KeyAvailable)
                {
                    // Read each key as it is pressed
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        stopwatch.Stop();
                        return userInput == targetWords;
                    }
                    else
                    {
                        userInput += keyInfo.KeyChar;
                    }
                }
            }
        }
    }
}
