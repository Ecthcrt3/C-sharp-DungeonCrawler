using DungeonClassLibrary;
using DungeonClassLibrary.Enemies;

namespace DungeonMethodLibrary
{
    public static class UI
    {
        public static int Roll(int die)
        {
            Random rand = new Random();
            return rand.Next(1, die + 1);
        }

        public static Player NewPlayer()
        {
            bool isValid = true;
            string name;
            byte[] stats = new byte[6];
            byte[] rolls = new byte[6];
            int input = 0;
            byte ac;

            do
            {
                Console.WriteLine("Please enter your Characters Name:\n");
                name = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"Welcome {name},\nNow you must determine your stats; this is done by rolling 4d6 keeping the highest 3 numbers.\nWe do this six times to get a number for each stat.\n(Press any key to roll your stats!)");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Wow look at those rolls!\nYou got: ");
                for (int i = 0; i < 6; i++)
                {
                    int[] tempRolls = new int[4];
                    for (int j = 0; j < 4; j++)
                    {
                        tempRolls[j] = Roll(6);
                    }
                    rolls[i] = (byte)(tempRolls.Sum() - tempRolls.Min());
                    Console.Write(rolls[i] + " ");
                }
                Console.WriteLine("\nNow we just have to assign them to the stats you want!\n(Press any key to start assigning stats)");
                Console.ReadKey();
                Console.Clear();
                foreach (var x in rolls)
                {
                    do
                    {
                        Console.WriteLine($"The {x} should go to . . . ?\n1) Strength - {stats[0]}\n2) Dexterity - {stats[1]}\n3) Constitution - {stats[2]}\n4) Intellegence - {stats[3]}\n5) Wisdom - {stats[4]}\n6) Charisma - {stats[5]}\n");
                        if (Int32.TryParse(Console.ReadKey(true).KeyChar.ToString(), out input) && input < 7 && input > 0)
                        {
                            if (stats[input - 1] == 0)
                            {
                                stats[input - 1] = x;
                                isValid = true;
                                Console.Clear();
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You have already set that stat please select another\n");
                                Console.ResetColor();
                                isValid = false;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please select a number between 1 and 6\n");
                            Console.ResetColor();
                            isValid = false;
                        }
                    } while (!isValid);
                }
                ac = 15; //CALC FROM CLASS SELECTION
                return new Player(name, ac, stats);
            } while (!isValid);
        }

        public static Enemy RandomEnemy()
        {
            Random random = new Random();

            Enemy wolf = new Wolf();
            return wolf;

        }
    }
}