namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool inCombat = false, isRunning = true, isAlive = true;
            string userInput;


            do
            {
                #region Character Creation
                
                #endregion
                do
                {
                    Console.WriteLine(GetRoom());
                    //TODO: get monster
                    do
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
                                inCombat = isAlive = isRunning = false;
                                break;
                            default:
                                break;
                        }
                    } while (inCombat);
                } while (isAlive);
            } while (isRunning);
        }//end Main

        private static string GetRoom()
        {
            Random rand = new Random();
            string[] material = { "stone", "wood", "dirt", "metal" };
            string[] size = { "6ft", "8ft", "10ft", "12ft", "14ft" };
            return ($"You enter a {size[rand.Next(6)]} by {size[rand.Next(6)]} by {size[rand.Next(6)]} room with {material[rand.Next(5)]} floors and {material[rand.Next(5)]} walls\n");
        }
    }//end class
}//end namespace