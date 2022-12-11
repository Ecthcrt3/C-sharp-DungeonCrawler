using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class DungeonMain
    {
        static void Main(string[] args)
        {
            //This Region holds the creation of needed variables and console window settings
            #region GameLauncher
            bool isRunning, isExploring, inCombat;
            Console.SetWindowSize(150, 45);
            Console.SetBufferSize(150, 45);
            Console.Title = "-----Dungeon Diving-----";
            #endregion

            //This Region contains the instructions for creating a new player character
            #region Character Creation
            isRunning = true;
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
