using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
    }

    public class Weapon : Item
    {
        private Dice _damageDice;
        public bool IsTwoHanded { get; set; }
        public Dice DamageDice { get; set; }
        public Weapon(int iD, string name, int weight, bool isTwoHanded, Dice damageDice)
        {
            ID = iD;
            Name = name;
            Weight = weight;
            IsTwoHanded = isTwoHanded;
            DamageDice = damageDice;
        }

        public byte RollDamage()
        {
            return (byte)_damageDice.Roll();
        }
    }

    public class Armor : Item
    {

    }
}
