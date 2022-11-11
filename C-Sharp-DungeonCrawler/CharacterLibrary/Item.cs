using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Item
    {
        //public int ID { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"---{Name}---\n{Weight} pounds\n{Description}";
        }
    }

    public class Weapon : Item
    {
        private Dice _damageDice;
        public bool IsTwoHanded { get; set; }
        public Dice DamageDice { get; set; }
        public DamageType DamageType { get; set; }
        public Weapon(int iD, string name, int weight, bool isTwoHanded, Dice damageDice)
        {
            Name = name;
            Weight = weight;
            IsTwoHanded = isTwoHanded;
            DamageDice = damageDice;
        }

        public override string ToString()
        {
            return $"---{Name}---\n{Weight} pounds\n{DamageDice} {DamageType}\n{Description}";
        }
        public int RollDamage()
        {
            return 0;
        }
    }

    public class Armor : Item
    {

    }

    
}
