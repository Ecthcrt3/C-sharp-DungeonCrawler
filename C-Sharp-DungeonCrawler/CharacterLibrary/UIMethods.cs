namespace DungeonLibrary
{
    public class UIMethods
    {

        public static void Welcome()
        {

        }

        public static Player CreatePlayer(Roll dice)
        {
            string userInput;
            Console.WriteLine("Please enter your Characters name");
            string name = Console.ReadLine();
            Console.Clear();

            byte[] stats = new byte[6];
            byte[] tempStats = new byte[6];
            for (int i = 0; i < 6; i++)
            {
                Console.Clear();
                Random rand = new Random();
                tempStats[i] =(byte)(dice.D6() + dice.D6() + dice.D6());
            }
            Console.Write("You rolled: ");
            foreach (byte stat in tempStats)
            {
                Console.Write(stat + " ");
            }
            Console.WriteLine("");
            for(int i = 0; i< 6; i++)
            {
                Console.WriteLine($"What stat would you like to put the {tempStats[i]} on?\n" +
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
                stats[Convert.ToByte(userInput) - 1] = tempStats[i];
                Console.Clear();
            }
            return new Player(name, stats);
        }
    }
}