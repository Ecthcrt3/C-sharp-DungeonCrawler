using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonClassLibrary;
using DungeonMethodLibrary;
using DungeonInterfaces;

namespace Dungeon
{
    public class DungeonMain
    {
        static void Main(string[] args)
        {
            //This Region holds the creation of needed variables and console window settings
            #region GameLauncher
            bool isRunning, isExploring, inCombat, isValid, isCreating;
            string userInput;
            Player user;
            Enemy enemy;
            Room currentRoom;
            Console.SetWindowSize(150, 45);
            Console.SetBufferSize(150, 45);
            Console.Title = "-----Dungeon Diving-----";
            isCreating = true;
            isRunning = true;
            #endregion

            //This Region contains the instructions for creating a new player character
            #region Character Creation
            do
            {
                user = UI.NewPlayer();
                do
                {
                    Console.WriteLine("Here is the Character you created!\n\n" + user.ToString());
                    Console.WriteLine("\nAre you satisfied with this character?\n Y/N  (press E to quit)");
                    userInput = Console.ReadKey(true).KeyChar.ToString();
                    isValid = true;
                    switch (userInput.ToUpper())
                    {
                        case "N":
                            Console.Clear();
                            Console.WriteLine("You didn't like that one?\nWell lets try again!");
                            isRunning = false;
                            break;
                        case "E":
                            isRunning = false;
                            isCreating = false;
                            break;
                        case "Y":
                            isCreating = false;
                            break;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Input not recognized. . . please try again");
                            Console.ResetColor();
                            isValid = false;
                            break;
                    }
                } while (!isValid);
                Console.Clear();
            } while (isCreating);
            #endregion

            //This Region is where the game will run until the character dies or the player chooses to quit
            #region GameLoop
            while (isRunning)
            {
                do
                {
                    Console.WriteLine($"{user.Name}, you are exploring the forest near your hometown and discover then entrance to a hidden lair with a solid looking door. What do you do?\n" +
                        $"\n1)Enter the Lair!\n2)Return to town");
                    userInput = Console.ReadKey(true).KeyChar.ToString();
                    Console.Clear();
                    isValid = true;
                    switch (userInput)
                    {
                        case "1":
                            isExploring = true;
                            while (isExploring)
                            {
                                currentRoom = Room.RandomRoom();
                                enemy = UI.RandomEnemy(user.Level);
                                Console.WriteLine($"You open the door and enter a {currentRoom}\nBetween you and the door you see a {enemy.Name}\n");
                                inCombat = true;
                                while (inCombat)
                                {
                                    Console.WriteLine("What would you like to do?\n1) Attack\n2) Run Away\n3) Display Character Stats\n4) Check Enemy Stats\n5) Exit Game");
                                    userInput = Console.ReadKey(true).KeyChar.ToString();
                                    Console.Clear();
                                    switch (userInput)
                                    {
                                        case "1":
                                            if (CombatManager.CalculateHit(user, enemy))
                                            {
                                                Console.WriteLine($"You hit the {enemy.Name} for {CombatManager.CalculateDamage(user, enemy)} points of damage!\n");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"You tried to attack the {enemy.Name} but missed!\n");
                                            }
                                            if (enemy.IsAlive())
                                            {
                                                if (CombatManager.CalculateHit(enemy, user))
                                                {
                                                    Console.WriteLine($"The {enemy.Name} attacked you and did {CombatManager.CalculateDamage(enemy, user)} points of damage!\n");
                                                    if (!user.IsAlive())
                                                    {
                                                        isExploring = false;
                                                        isRunning = false;
                                                        inCombat = false;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"The {enemy.Name} tried to attack you but missed!\n");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"You Killed the {enemy.Name} and earned {enemy.XpReward} experience!\n");
                                                user.Experience += enemy.XpReward;
                                                if (user.HasLevelUp())
                                                {
                                                    Console.WriteLine($"Killing the {enemy.Name} gave you enough xp to level up!\n" +
                                                        $"you have been healed to full life and gained 10 more Max Health Points!");
                                                }
                                                inCombat = false;
                                            }
                                            break;
                                        case "2":
                                            if (user.MainStats[1] > enemy.MainStats[1])
                                            {
                                                Console.WriteLine($"You successfully ran away from the {enemy.Name}!");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"You ran away but the {enemy.Name} hit you for {CombatManager.CalculateDamage(enemy, user)} when you turned your back!\n");
                                            }
                                            inCombat = false;   
                                            break;
                                        case "3":
                                            Console.WriteLine(user);
                                            break;
                                        case "4":
                                            Console.WriteLine(enemy);
                                            break;
                                        case "5":
                                            inCombat = false;
                                            isExploring = false;
                                            isRunning = false;
                                            break;
                                        default:
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Input not recognized. . . please try again");
                                            Console.ResetColor();
                                            break;
                                    }
                                }
                                if (user.IsAlive())
                                {
                                    do
                                    {
                                        Console.WriteLine($"You are now in a safe room.\nWhat would you like to do now?\n\n1) Advance to the next room\n2) Rest (1 rest per Level)\n3) Leave");
                                        userInput = Console.ReadKey(true).KeyChar.ToString();
                                        Console.Clear();
                                        switch (userInput)
                                        {
                                            case "1":
                                                Console.WriteLine("You push your luck: ");
                                                break;
                                            case "2":
                                                if (!user.HasRested)
                                                {
                                                    Console.WriteLine("You heal up a bit before advancing to the next rooom.");
                                                    user.CurrentHealth += 10;
                                                    user.HasRested = true;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("You have already rested this level, you must level up before resting again");
                                                }
                                                break;
                                            case "3":
                                                isExploring = false;
                                                isRunning = false;
                                                isValid = true;
                                                break;
                                            default:
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Input not recognized. . . please try again\n");
                                                Console.ResetColor();
                                                break;
                                        }

                                    } while (!isValid);
                                }
                            }
                            break;
                        case "2":
                            isRunning = false;
                            Console.WriteLine($"You Chicken out and return to town, adventuring doesnt seem to be for {user.Name} =(");
                            break;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Input not recognized. . . please try again");
                            Console.ResetColor();
                            isValid = false;
                            break;
                    }
                } while (!isValid);

            }
            #endregion

            //This Regions hold the end credits for when the player quits or the character dies
            #region End Credits
            Console.Clear();
            if (user.Level == 20)
            {
                Console.WriteLine("Congratulations!\nYou Reached Level 20 and cleared the dungeon!\n");
            }
            else if (!user.IsAlive())
            {
                Console.WriteLine("YOU DIED!!\nBetter luck Next time. . . \n");

            }

            Console.WriteLine($"You managed to make it to level {user.Level}!\nThank you for Playing!\n");
            #endregion
        }//End Main
    }//End Class
}//End NameSpace
