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
                        Console.WriteLine($"The {x} should go to . . . ?\n1)Strength - {stats[0]}\n2)Dexterity - {stats[1]}\n3)Constitution - {stats[2]}\n4)Intellegence - {stats[3]}\n5)Wisdom - {stats[4]}\n6)Charisma - {stats[5]}\n");
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

        //public static Player CreatePlayer()
        //{
        //    string userInput, name = "";
        //    int userSelection, counter;
        //    Races race = Races.Dwarf;
        //    Proffessions proffession = Proffessions.Barbarian;
        //    byte[] stats = new byte[6], rolls = new byte[6];
        //    bool isValid = true;
        //    do
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Please enter your characters name:");
        //        userInput = Console.ReadLine();
        //        if (userInput == null)
        //        {
        //            Console.Clear();
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("Your character must have a name. . . ");
        //            isValid = false;
        //            Console.ForegroundColor = ConsoleColor.White;
        //        }
        //        else
        //        {
        //            name = userInput;
        //            isValid = true;
        //        }
        //    } while (!isValid);//end Character Name

        //    do
        //    {
        //        Console.Clear();
        //        isValid = true;
        //        Console.WriteLine("What Race is your character?");
        //        counter = 1;
        //        foreach (var races in Enum.GetValues(typeof(Races)))
        //        {
        //            Console.Write(counter++ + ") ");
        //            Console.WriteLine(races);
        //        }
        //        userSelection = Int32.Parse(Console.ReadLine()) - 1;
        //        switch ((Races)userSelection)
        //        {
        //            case Races.Dwarf:
        //                race = Races.Dwarf;
        //                break;
        //            case Races.Elf:
        //                race = Races.Elf;
        //                break;
        //            case Races.Halfling:
        //                race = Races.Halfling;
        //                break;
        //            case Races.Human:
        //                race = Races.Human;
        //                break;
        //            case Races.Dragonborn:
        //                race = Races.Dragonborn;
        //                break;
        //            case Races.Gnome:
        //                race = Races.Gnome;
        //                break;
        //            case Races.HalfElf:
        //                race = Races.HalfElf;
        //                break;
        //            case Races.HalfOrc:
        //                race = Races.HalfOrc;
        //                break;
        //            case Races.Tiefling:
        //                race = Races.Tiefling;
        //                break;
        //            default:
        //                Console.WriteLine("Input Not valid, please try again. . . ");
        //                isValid = false;
        //                break;
        //        }
        //    } while (!isValid);//end Character Race

        //    do
        //    {
        //        Console.Clear(); isValid = true;
        //        Console.WriteLine("Please Select your characters Proffession.");
        //        counter = 1;
        //        foreach (var prof in Enum.GetValues(typeof(Proffessions)))
        //        {
        //            Console.Write(counter++ + ") ");
        //            Console.WriteLine(prof);
        //        }
        //        userSelection = Int32.Parse(Console.ReadLine());
        //        switch ((Proffessions)userSelection)
        //        {
        //            case Proffessions.Fighter:
        //                proffession = Proffessions.Fighter;
        //                break;
        //            case Proffessions.Paladin:
        //                proffession = Proffessions.Paladin;
        //                break;
        //            case Proffessions.Wizard:
        //                proffession = Proffessions.Wizard;
        //                break;
        //            case Proffessions.Bard:
        //                proffession = Proffessions.Bard;
        //                break;
        //            case Proffessions.Cleric:
        //                proffession = Proffessions.Cleric;
        //                break;
        //            case Proffessions.Rogue:
        //                proffession = Proffessions.Rogue;
        //                break;
        //            case Proffessions.Warlock:
        //                proffession = Proffessions.Warlock;
        //                break;
        //            case Proffessions.Barbarian:
        //                proffession = Proffessions.Barbarian;
        //                break;
        //            case Proffessions.Sorcerer:
        //                proffession = Proffessions.Sorcerer;
        //                break;
        //            default:
        //                Console.WriteLine("Input not recognized, please try again. . .");
        //                isValid = false;
        //                break;
        //        }
        //    } while (!isValid);//end Character Proffession

        //    for (int i = 0; i < 6; i++)
        //    {
        //        rolls[i] = (byte)(Roll(6) + Roll(6) + Roll(6));
        //    }
        //    counter = 0;
        //    Console.Clear();
        //    do
        //    {
        //        isValid = true;
        //        foreach (var roll in rolls)
        //        {
        //            Console.Write(roll + " ");
        //        }
        //        Console.WriteLine("\nPlease select which stat you would like to be {0}", rolls[counter]);
        //        Console.WriteLine("1) Strength\n" +
        //            "2) Dexterity\n" +
        //            "3) Constitution\n" +
        //            "4) Intellegence\n" +
        //            "5) Wisdom\n" +
        //            "6) Charisma");
        //        userSelection = Int32.Parse(Console.ReadLine());
        //        if (stats[userSelection - 1] != 0)
        //        {
        //            Console.Clear();
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("You have already chosen that stat, please choose another. . . ");
        //            counter--;
        //            isValid = false;
        //            Console.ForegroundColor = ConsoleColor.White;
        //        }
        //        else
        //        {
        //            stats[userSelection - 1] = rolls[counter++];
        //            Console.Clear();
        //        }
        //    } while (!isValid || counter < 6);

        //    return new Player(name, stats, race, proffession);

        //}

        public static Enemy RandomEnemy()
        {
            Random random = new Random();

            Enemy wolf = new Wolf();
            return wolf;

        }
    }
}