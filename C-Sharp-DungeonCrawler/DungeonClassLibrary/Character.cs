namespace DungeonClassLibrary
{
    public class Character
    {
        //fields
        private int _currentHealth;

        //props
        public int MaxHealth { get; set; }
        public int CurrentHealth
        {
            get { return _currentHealth; }
            set
            {
                if (value > MaxHealth)
                { _currentHealth = MaxHealth; }
                else
                { _currentHealth = value; }
            }
        }
        public string Name { get; set; }
        public byte[] Stats { get; set; }

        //Constructors
        public Character()
        {

        }
        public Character(string name, byte[] stats)
        {
            this.Stats = new byte[6];
            Name = name;
            Stats[0] = stats[0];
            Stats[1] = stats[1];
            Stats[2] = stats[2];
            Stats[3] = stats[3];
            Stats[4] = stats[4];
            Stats[5] = stats[5];
            MaxHealth = 10 + (Stats[2]/2-10);
            CurrentHealth = MaxHealth;
        }



        //Methods
        public bool IsAlive()
        {
            return (CurrentHealth > 0) ? true : false;
        }

        public override string ToString()
        {
            return ($"Name:  {Name}\n" +
                $"Current Health: {CurrentHealth}/{MaxHealth}\n\n" +
                $"--Stats--\n" +
                $"Strength: {Stats[0]}\n" +
                $"Dexterity: {Stats[1]}\n" +
                $"Constitution: {Stats[2]}\n" +
                $"Intellegence: {Stats[3]}\n" +
                $"Wisdom: {Stats[4]}\n" +
                $"Charisma: {Stats[5]}\n");
        }

        public virtual int Attack()
        {
            return 0;
        }

        public virtual int Damage()
        {
            return 0;
        }

    }
}