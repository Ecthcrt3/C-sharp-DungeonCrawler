using DungeonLibrary;

namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            string userInput;

            Console.Title = "####### Mines of Mystery#######";

            do
            {
                Console.WriteLine("Welcome to the Mines of Mystery,\n" +
                    "1) Start New Game\n" +
                    "2) Exit Game");
                userInput = Console.ReadLine();
                Console.Clear();
                switch (userInput)
                {
                    case "1":
                        //TODO Start game();
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