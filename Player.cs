using System;
namespace ProjectComp
{
    public class Player
    {
        private static int maxID;
        private int playerID;
        public string playerName;
        private int playerLevel;
        private int playerLives;
        private static int count;

        public Player(string playerName)
        {
            this.playerID = count;
            this.playerName = playerName;
            this.playerLevel = 1;
            this.playerLives = 3;
        }

        public int GetPlayerID()
        {
            return playerID;
        }

        public string GetPlayerName()
        {
            return playerName;
        }

        public int GetPlayerLevel()
        {
            return playerLevel;
        }

        public void SetPlayerLevel(int playerLevel)
        {
            this.playerLevel = playerLevel;
        }

        public int GetPlayerLives()
        {
            return playerLives;
        }

        public void SetPlayerLives(int playerLives)
        {
            this.playerLives = playerLives;
        }

        public static int GetCount()
        {
            return count;
        }

        public static void SetCount(int count)
        {
            Player.count = count;
        }

        public static void IncCount()
        {
            count++;
        }

        public override string ToString()
        {
            return $"{playerID}\t{playerName}\tLevel: {playerLevel}\tLives: {playerLives}";
        }
        public string ToFile(){
            return $"{playerName}";
        }
    }
}
