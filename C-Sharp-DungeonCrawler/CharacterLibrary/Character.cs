namespace CharacterLibrary
{
    public class Character
    {
        private byte _health;
        private string _name;
        private byte _strength;
        private byte _dextarity;
        private byte _constitution;
        private byte _intellegence;
        private byte _wisdom;
        private byte _charisma;
        private bool _isAlive;

        public byte Health { get; set; }
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
        public Player(string name, byte[] stats)
        {
            Name = name;
            Strength = stats[0];
            Dexterity = stats[1];
            Constitution = stats[2];
            Intellegence = stats[3];
            Wisdom = stats[4];
            Charisma = stats[5];
            Health = (byte)(10 + (Constitution - 10) / 2);
            IsAlive = true;
        }
    }
}