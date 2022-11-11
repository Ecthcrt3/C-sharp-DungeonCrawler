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
        public Races Race { get; set; }

        private byte Attack()
        {
            return  (byte)((Strength - 10)/2);
        }
    }

    public class Player : Character
    {
        public byte Level { get; set; }
        public Player()
        {
            IsAlive = false;
        }
        public Player(string name,Races race ,byte[] stats)
        {
            Name = name;
            Race = race;
            Strength = stats[0];
            Dexterity = stats[1];
            Constitution = stats[2];
            Intellegence = stats[3];
            Wisdom = stats[4];
            Charisma = stats[5];
            MaxHealth = currentHealth = (byte)(10 + (Constitution - 10) / 2);
            Level = 1;
            IsAlive = true;
        }

        public override string ToString()
        {
            //return base.ToString();
            return ($"Name: {Name}\nRace: {Race}\nMax HP: {MaxHealth}\nStats:\nStr: {Strength}\nDex: {Dexterity}\nCon: {Constitution}\nInt: {Intellegence}\nWis: {Wisdom}\nCha: {Charisma}\nStatus: " + (IsAlive?"Alive":"Dead"));
        }
    }
}