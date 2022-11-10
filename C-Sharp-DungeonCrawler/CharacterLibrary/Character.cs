namespace DungeonLibrary
{
    public class Character
    {
        public byte MaxHealth { get; set; }
        public byte currentHealth { get; set; }
        public string? Name { get; set; }
        public byte Strength { get; set; }
        public byte Dexterity { get; set; }
        public byte Constitution { get; set; }
        public byte Intellegence { get; set; }
        public byte Wisdom { get; set; }
        public byte Charisma { get; set; }
        public bool IsAlive { get; set; }

        private byte Attack()
        {
            return  (byte)((Strength - 10)/2 + 5);
        }
    }

    public class Player : Character
    {
        public Player()
        {
            IsAlive = false;
        }
        public Player(string name, byte[] stats)
        {
            Name = name;
            Strength = stats[0];
            Dexterity = stats[1];
            Constitution = stats[2];
            Intellegence = stats[3];
            Wisdom = stats[4];
            Charisma = stats[5];
            MaxHealth = currentHealth = (byte)(10 + (Constitution - 10) / 2);
            IsAlive = true;
        }

        public override string ToString()
        {
            //return base.ToString();
            return ($"Name: {Name}\nMax HP: {MaxHealth}\nStats:\nStr: {Strength}\nDex: {Dexterity}\nCon: {Constitution}\nInt: {Intellegence}\nWis: {Wisdom}\nCha: {Charisma}\nStatus: " + (IsAlive?"Alive":"Dead"));
        }

        public static Player CreateCharacter()
        {
            string userInput;
            Console.WriteLine("Please enter your Characters name");
            string name = Console.ReadLine();
            Console.Clear();
            byte[] stats = new byte[6];
            byte tempStat;
            for (int i = 0; i < 6; i++)
            {
                Console.Clear();
                Random rand = new Random();
                tempStat = (byte)rand.Next(3, 19);
                Console.WriteLine($"Your Rolled a {tempStat} what stat would you like to put this on?\n" +
                    $"1) Strength\n" +
                    $"2) Dexterity\n" +
                    $"3) Constitution\n" +
                    $"4) Intellegence\n" +
                    $"5) Wisdom\n" +
                    $"6) Charisma\n");
                userInput = Console.ReadLine();
                while (stats[Convert.ToByte(userInput) - 1] != 0)
                {
                    Console.WriteLine("That stat has already been chosen please choose another");
                    userInput = Console.ReadLine();
                }
                stats[Convert.ToByte(userInput) - 1] = tempStat;
            }
            return new Player(name, stats);
        }

    }
}