using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonClassLibrary
{
    public class Weapon : Item
    {
        public int DamageDie { get; set; }
        public bool IsTwoHanded { get; set; }
        public int NbrDamageDie { get; set; }
        public DamageType Type { get; set; }

        public Weapon(string name, string description, int nbrDamageDie, int damageDie, DamageType Type, bool isTwoHanded) : base(name, description)
        {
            NbrDamageDie = nbrDamageDie;
            DamageDie = damageDie;
            IsTwoHanded = isTwoHanded;
        }

        public override string ToString()
        {
            return $"{Name}\n" +
                $"{NbrDamageDie}d{DamageDie}damage\n" +
                $"{(IsTwoHanded? "2 Handed":"1 Handed")}\n" +
                $"{Description}";
        }
    }
}
