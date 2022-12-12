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
            Races race = Races.Dwarf;
            Proffessions prof = Proffessions.Fighter;
            byte[] stats = new byte[6];
            byte[] rolls = new byte[6];
            int input = 0;
            byte ac;

            do
            {
                Console.WriteLine("Please enter your Characters Name:\n");
                name = Console.ReadLine();
                Console.Clear();
                do
                {
                    isValid = true;
                    Console.WriteLine("What race is your character?\n" +
                        "\n1) Dwarf" +
                        "\n2) Elf" +
                        "\n3) Halfling" +
                        "\n4) Human" +
                        "\n5) Dragonborn" +
                        "\n6) Gnome" +
                        "\n7) HalfElf" +
                        "\n8) HalfOrc" +
                        "\n9) Tiefling");
                    if (Int32.TryParse(Console.ReadKey(true).KeyChar.ToString(), out input) && input > 0 && input < 7)
                    {
                        race = (Races)input - 1;
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Input not recognized. . . please try again");
                        Console.ResetColor();
                        isValid = false;
                    }
                } while (!isValid);
                Console.Clear();
                do
                {
                    isValid = true;
                    Console.WriteLine("What Class would you like your character to be?\n" +
                        "\n1) Fighter" +
                        "\n2) Paladin" +
                        "\n3) Cleric" +
                        "\n4) Rogue" +
                        "\n5) Barbarian");
                    if (Int32.TryParse(Console.ReadKey(true).KeyChar.ToString(), out input) && input > 0 && input < 6)
                    {
                        prof = (Proffessions)input - 1;
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Input not recognized. . . please try again");
                        Console.ResetColor();
                        isValid = false;
                    }
                } while (!isValid);
                Console.Clear();
                Console.WriteLine($"Welcome {name} the {race} {prof},\nNow you must determine your stats; this is done by rolling 4d6 keeping the highest 3 numbers.\nWe do this six times to get a number for each stat.\n(Press any key to roll your stats!)");
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
                        Console.WriteLine($"The {x} should go to . . . ?\n\n1) Strength - {stats[0]}\n2) Dexterity - {stats[1]}\n3) Constitution - {stats[2]}\n4) Intellegence - {stats[3]}\n5) Wisdom - {stats[4]}\n6) Charisma - {stats[5]}\n");
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
                return new Player(name, stats, race, prof);
            } while (!isValid);
        }

        public static Enemy RandomEnemy(int level)
        {
            Random random = new Random();
            Enemy enemy;
            switch (random.Next(1, 5))
            {
                case 1:
                    enemy = new Goblin();
                    enemy.LevelScaling(level);
                    return enemy;
                case 2:
                    enemy = new Spider();
                    enemy.LevelScaling(level);
                    return enemy;
                case 3:
                    enemy = new Skeleton();
                    enemy.LevelScaling(level);
                    return enemy;
                case 4:
                    enemy = new Wolf();
                    enemy.LevelScaling(level);
                    return enemy;
                default:
                    return null;
            }
        }

        public static  Item ItemDictionary(int id)
        {
             Dictionary<int, Item> itemList = new Dictionary<int, Item>();
            itemList.Add(1, new Weapon("club", "a Basic wooden club", 1, 4, DamageType.bludgeoning, false));
            itemList.Add(2, new Weapon("Mace", "a steel mace", 1, 6, DamageType.bludgeoning, false));
            itemList.Add(3, new Weapon("Dagger", "a short iron dagger", 1, 4, DamageType.piercing, false));
            itemList.Add(4, new Weapon("Sword", "a short 1 handed sword", 1, 6, DamageType.slashing, false));
            itemList.Add(5, new Weapon("Warhammer", "a large 1 handed hammer", 1, 8, DamageType.bludgeoning, false));
            return itemList[id];
        }
    }//end class

}