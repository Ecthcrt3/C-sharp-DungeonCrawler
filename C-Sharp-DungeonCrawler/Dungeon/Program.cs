using DungeonClassLibrary;
using DungeonClassLibrary.Enemies;
using DungeonInterfaces;
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
            Console.SetWindowSize(150, 45);
            Console.SetBufferSize(150, 45);
            Console.Title = "####### Mines of Mystery #######";
            #region Enemies
                List<Enemy> enemies = new List<Enemy>();
                enemies.Add(new Wolf());
                enemies.Add(new Goblin());
                enemies.Add(new Skeleton());
                enemies.Add(new Spider());
                
            #endregion
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

                        user = UI.CreatePlayer();
                        while (isExploring)
                        {
                            Console.Clear();
                            currentRoom = Room.RandomRoom();
                            Console.WriteLine("You have entered a " + currentRoom);
                            enemy = UI.RandomEnemy(enemies);
                            Console.WriteLine("Standing in the middle of the room is a " + enemy.Name);
                            inCombat = true;
                            while (inCombat)
                            {
                                Console.WriteLine("What would you like to do now?\n");
                                Console.WriteLine("1) Attack\n2) Run Away\n3)Display Enemy Info\n4)Display Player Info");
                                userInput = Console.ReadLine();
                                switch (userInput)
                                {
                                    case "1":
                                        Console.Clear();
                                        if (CombatManager.CalculateHit(user, enemy))
                                        {
                                            Console.WriteLine($"You hit the {enemy.Name} for {CombatManager.CalculateDamage(user, enemy)} points of damage!\n");
                                        }
                                        else Console.WriteLine($"Oh no you missed the {enemy.Name}!\n");
                                        if (!enemy.IsAlive())
                                        {
                                            inCombat = false;
                                            user.Experience += enemy.XpReward;
                                            user.LevelUp(user.Experience);
                                            Console.WriteLine($"You killed the {enemy.Name}!\nYou earned {enemy.XpReward} xp");
                                            Console.WriteLine(user.Experience);
                                            break;
                                        }
                                        if (CombatManager.CalculateHit(enemy, user))
                                        {
                                            Console.WriteLine($"The {enemy.Name} hit you for {CombatManager.CalculateDamage(enemy, user)} points of damage!\n");
                                        }
                                        else Console.WriteLine($"The {enemy.Name} tried to attack you but missed!\n");
                                        if (!user.IsAlive())
                                        {
                                            inCombat = false;
                                            isExploring = false;
                                            isRunning = false;
                                            Console.WriteLine($"YOU DIED....\nBetter luck next time.\nYou reached level {user.Level}");
                                        }
                                        break;
                                    case "2":
                                        Console.Clear();
                                        inCombat = false;
                                        break;
                                    case "3":
                                        Console.Clear();
                                        Console.WriteLine(enemy.ToString());
                                        break;
                                    case "4":
                                        Console.Clear();
                                        Console.WriteLine(user.ToString());
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("Input not recognized . . . please try again");
                                        break;
                                }
                            }
                            if (user.IsAlive())
                            {
                                if (enemy.IsAlive())
                                {
                                    Console.WriteLine($"You successfully ran away from the {enemy.Name}!");
                                }
                                isResting = true;
                                while (isResting)
                                {
                                    Console.WriteLine("What would you like to do now?\n\n1)Advance to next room\n2)Rest up a bit\n3)Chicken out and leave\n");
                                    userInput = Console.ReadLine();
                                    switch (userInput)
                                    {
                                        case "1":
                                            isResting = false;
                                            break;
                                        case "2":
                                            if (user.CurrentHealth < user.MaxHealth)
                                            {
                                                user.CurrentHealth += 10;
                                                Console.Clear();
                                                Console.WriteLine("You rested and healed up a bit\n");
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You are already full health!");
                                            }
                                            break;
                                        case "3":
                                            isResting = false;
                                            isExploring = false;
                                            isRunning = false;
                                            Console.Clear();
                                            Console.WriteLine($"Thank you for playing!\nYou ended the game at Level: {user.Level}!\n");
                                            break;
                                        default:
                                            Console.Clear();
                                            Console.WriteLine("Input not recognized . . . please try again");
                                            break;
                                    }
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