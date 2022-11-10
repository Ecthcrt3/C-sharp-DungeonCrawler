using DungeonLibrary;

namespace UILibrary
{
    public class UIMethods
    {
        string userInput;
        public static void Welcome()
        {

        }
        public static Player CreateCharacter()
        {
            Console.WriteLine("Please enter your Characters name");
            string name = Console.ReadLine();
            Console.Clear();
            byte[] stats = new byte[6];
            byte tempStat;
            for (int i = 0; i < 6; i++)
            {
                Console.Clear();
                Random rand = new Random();
                tempStat = (byte)rand.Next(3, 19);
                Console.WriteLine($"Your Rolled a {tempStat} what stat would you like to put this on?\n" +
                    $"1) Strength\n" +
                    $"2) Dexterity\n" +
                    $"3) Constitution\n" +
                    $"4) Intellegence\n" +
                    $"5) Wisdom\n" +
                    $"6) Charisma\n");
                userInput = Console.ReadLine();
                while (stats[Convert.ToByte(userInput) - 1] != 0)
                {
                    Console.WriteLine("That stat has already been chosen please choose another");
                    userInput = Console.ReadLine();
                }
                stats[Convert.ToByte(userInput) - 1] = tempStat;
            }
            return new Player(name, stats);
        }
    }
}