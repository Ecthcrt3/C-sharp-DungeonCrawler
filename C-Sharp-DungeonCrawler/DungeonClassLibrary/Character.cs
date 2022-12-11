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
                if (value >= MaxHealth)
                {
                    _currentHealth = MaxHealth;
                }
                else
                {
                    _currentHealth = value;
                }
            }
        }
        public string Name { get; set; }
        public byte ArmorClass { get; set; }
        public byte[] MainStats { get; set; }

        //ctors
        public Character() { }

        public Character(string name, byte armorClass, byte[] mainStats)
        {
            Name = name;
            ArmorClass = armorClass;
            MainStats = mainStats;
            MaxHealth = 10;
            CurrentHealth = 10;
        }

        //methods

        public bool IsAlive()
        {
            return CurrentHealth > 0;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nCurrent Health: {CurrentHealth}";
        }

        /// <summary>
        /// Allows the user to roll a die of any value resulting in a random number from 1 to the size die they rolled
        /// </summary>
        /// <param name="die"></param>
        /// <returns>Random int from 1 - die</returns>
        public int Roll(int die)
        {
            Random rand = new Random();
            return rand.Next(1, die + 1);
        }


        //Methods needed for the ICombatible interface
        public void TakeDamage(int dmg)
        {
            CurrentHealth -= dmg;
        }

        public byte GetAC()
        {
            return ArmorClass;
        }

        public abstract int MakeAttack();
        public abstract int DoDamage();

    }//End Class
}//End Namespace