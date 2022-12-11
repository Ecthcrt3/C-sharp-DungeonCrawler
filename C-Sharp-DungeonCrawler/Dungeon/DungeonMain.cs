using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonClassLibrary;
using DungeonMethodLibrary;

namespace Dungeon
{
    public class DungeonMain
    {
        static void Main(string[] args)
        {
            //This Region holds the creation of needed variables and console window settings
            #region GameLauncher
            bool isRunning, isExploring, inCombat, isValid,isCreating;
            string userInput;
            Player user;
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
                Console.WriteLine("Here is the Character you created!\n" + user.ToString());
                Console.WriteLine("Are you satisfied with this character?\n Y/N  (press E to quit)");
                userInput = Console.ReadKey(true).KeyChar.ToString();
                isValid = true;
                do
                {
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
                            isValid = false;
                            break;
                    }
                } while (!isValid);

            } while (isCreating);
            #endregion

            //This Region is where the game will run until the character dies or the player chooses to quit
            #region GameLoop
            while (isRunning)
            {
                isExploring = true;
                while (isExploring)
                {
                    inCombat = true;
                    while (inCombat)
                    {
                        Console.WriteLine("YOU MADE IT THIS FAR!");
                        Console.ReadLine();
                        isRunning = false;
                        isExploring = false;
                        inCombat = false;
                    }
                }
            }
            #endregion

            //This Regions hold the end credits for when the player quits or the character dies
            #region End Credits

            #endregion
        }//End Main
    }//End Class
}//End NameSpace
