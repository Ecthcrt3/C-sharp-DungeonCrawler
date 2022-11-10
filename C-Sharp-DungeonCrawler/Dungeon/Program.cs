using DungeonLibrary;

namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool inCombat = false, isRunning = true, isExploring = false;
            string userInput;
            Player user = new Player();

            do
            {
                #region Character Creation
                Console.WriteLine("Welcome to the Mines of Madness,\n" +
                    "1) Create new Character\n" +
                    "2) Exit Game\n");
                userInput = Console.ReadLine();
                Console.Clear();
                switch (userInput)
                {
                    case "1":
                        user = Player.CreateCharacter();
                        break;
                    case "2":
                        Console.WriteLine("Thank you for playing!");
                        isRunning = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Input not recognized, Please try again");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                Console.WriteLine(user);
                #endregion
                while (user.IsAlive && isExploring)
                {
                    Console.WriteLine(GetRoom());
                    //TODO: get monster
                    while (inCombat)
                    {
                        Console.WriteLine("What would you like to do?" +
                            "\n(1) Attack" +
                            "\n(2) Run Away" +
                            "\n(3) Character Info" +
                            "\n(4) Monster Info" +
                            "\n(5) Exit");
                        userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "1":
                                //TODO: player.attack()
                                break;
                            case "2":
                                //TODO: player.runaway()
                                break;
                            case "3":
                                //TODO: player.info();
                                break;
                            case "4":
                                //TODO: monster.info();
                                break;
                            case "5":
                                Console.WriteLine("Thank you for playing!");
                                inCombat = isExploring = isRunning = false;
                                break;
                            default:
                                break;
                        }//end switch
                    }//end while
                    if (!inCombat)
                    {
                        Console.WriteLine("The room is clear, what would you like to do?\n" +
                            "1) Advance to the next room\n" +
                            "2) Take a rest\n" +
                            "3) Chicken out");

                            userInput = Console.ReadLine();
                            switch (userInput)
                            {
                                case "1":
                                case "2":
                                case "3":
                                default:
                                    break;
                            }
                    }
                }//end while
            } while (isRunning);//end dowhile
        }//end Main

        private static string GetRoom()
        {
            Random rand = new Random();
            string[] material = { "stone", "wood", "dirt", "metal" };
            string[] size = { "6ft", "8ft", "10ft", "12ft", "14ft" };
            return ($"You enter a {size[rand.Next(5)]} by {size[rand.Next(5)]} by {size[rand.Next(5)]} room with {material[rand.Next(4)]} floors and {material[rand.Next(4)]} walls\n");
        }
    }//end class
}//end namespace