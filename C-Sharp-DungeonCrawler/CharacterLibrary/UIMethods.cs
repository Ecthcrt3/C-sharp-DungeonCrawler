namespace DungeonLibrary
{
    public class UIMethods
    {

        public static void Welcome()
        {

        }

        public static Player CreatePlayer()
        {
            string userInput;
            Console.WriteLine("Please enter your Characters name");
            string name = Console.ReadLine();
            Console.Clear();
            int counter = 1;
            Console.WriteLine("What Race is your Character? please enter the number of the selection");
            foreach(var race in Enum.GetValues(typeof(Races)))
            {
                Console.WriteLine(counter++ + ") " + race);
            }
            int tempRace = (Int32.Parse(Console.ReadLine()) - 1 );
            byte[] stats = new byte[6];
            byte[] tempStats = new byte[6];
            for (int i = 0; i < 6; i++)
            {
                Console.Clear();
                Random rand = new Random();
                tempStats[i] = (byte)(Roll(6) + Roll(6) + Roll(6));
            }
            for(int i = 0; i< 6; i++)
            {
                Console.Write("You rolled: ");
                foreach (byte stat in tempStats)
                {
                    Console.Write(stat + " ");
                }
                Console.WriteLine("\n");
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
            Console.WriteLine((Races)tempRace);
            return new Player(name, (Races)tempRace ,stats);
        }

        public static int Roll(int sides)
        {
            Random rand = new Random();
            switch ((Dice)sides)
            {
                case Dice.d4:
                    return rand.Next(1, 5);
                case Dice.d6:
                    return rand.Next(1, 7);
                case Dice.d10:
                    return rand.Next(1, 11);
                case Dice.d12:
                    return rand.Next(1, 13);
                case Dice.d20:
                    return rand.Next(1, 20);
                case Dice.d100:
                    return rand.Next(1, 101);
                default:
                    return 0;
            }
        }
    }
}