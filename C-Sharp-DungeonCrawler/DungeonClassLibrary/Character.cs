using DungeonInterfaces;

namespace DungeonClassLibrary
{
    public abstract class Character : ICombatable
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
        public byte ArmorClass { get; set; }

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
            ArmorClass = 12;
        }



        //Methods
        public bool IsAlive()
        {
            return (CurrentHealth > 0);
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

        public static int Roll(int die)
        {
            Random rand = new Random();
            return rand.Next(1, die + 1);
        }

        public void TakeDamage(int dmg)
        {
            CurrentHealth -= dmg;
        }

        public int GetAC()
        {
            return ArmorClass;
        }
        public abstract int DoDamage();
        public abstract int MakeAttack();
    }
}