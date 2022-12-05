using DungeonClassLibrary;
using DungeonClassLibrary.Enemies;
using DungeonMethodLibrary;
using System.ComponentModel;

namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            bool isExploring = true;
            bool inCombat = false;
            bool isResting = false;
            string userInput;
            Room currentRoom;
            Player user;
            Enemy enemy;
            //Roll dice = new Roll();
            Console.SetWindowSize(150, 45);
            Console.SetBufferSize(150, 45);
            Console.Title = "####### Mines of Mystery #######";
            do
            {
                Console.WriteLine("Welcome to the Mines of Mystery,\n" +
                     "1) Start New Game\n" +
                     "2) Exit Game\n");
                userInput = Console.ReadLine();
                Console.Clear();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Please enter your Characters Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Please enter your Characters Race: ");
                        string race = Console.ReadLine();
                        Console.WriteLine("Please enter your Characters Class: ");
                        string prof = Console.ReadLine();
                        user = new Player(name);
                        while (isExploring)
                        {
                            currentRoom = Room.RandomRoom();
                            Console.WriteLine("You have entered a " + currentRoom);
                            enemy = new Wolf();
                            Console.WriteLine("Standing in the middle of the room is a " + enemy.Name);
                            inCombat = true;
                            while (inCombat)
                            {
                                Console.WriteLine("What would you like to do?\n");
                                Console.WriteLine("1) Attack\n2)Run Away");
                                userInput = Console.ReadLine();
                                switch (userInput)
                                {
                                    case "1":
                                        user.Attack();
                                        if (enemy.CurrentHealth <= 0)
                                        {
                                            inCombat = false;
                                        }
                                        break;
                                    case "2":
                                        inCombat = false;
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("Input not recognized . . . please try again");
                                        break;
                                }
                            }
                            if (!enemy.IsAlive())
                            {
                                Console.WriteLine("You killed the " + enemy.Name + "!");
                            }
                            else
                            {
                                Console.WriteLine("You successfully ran away from the {1}!", enemy.Name);
                            }
                            isResting = true;
                            while (isResting)
                            {
                                Console.WriteLine("What would you like to do now?\n1)Advance to next room\n2)Rest up a bit\n3)Chicken out and leave");
                                userInput = Console.ReadLine();
                                switch (userInput)
                                {
                                    case "1":
                                        isResting = false;
                                        break;
                                    case "2":
                                        if(user.CurrentHealth < user.MaxHealth )
                                        {
                                            user.CurrentHealth += 10;
                                            Console.WriteLine("You rested and healed up a bit");
                                        }
                                        break;
                                    case "3":
                                        Console.WriteLine($"Thank you for playing!\nYou ended the game at Level: {user.Level}!");
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("Input not recognized . . . please try again");
                                        break;
                                }
                            }

                        }
                        break;
                    case "2":
                        Console.WriteLine("Thank you for playing!");
                        isRunning = !isRunning;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Input not Recognized, please try again\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }//end switch
            } while (isRunning);//end Do While
        }//end Main

    }//end class
}//end namespace