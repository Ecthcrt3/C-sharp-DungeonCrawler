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
        public DamageType Type { get; set; }
        public int ToHit { get; set; }

        public Weapon(int id, string name, int weight, string description, int damageDie, bool isTwoHanded, DamageType type, int toHit) : base(id, name, weight, description)
        {
            DamageDie = damageDie;
            IsTwoHanded = isTwoHanded;
            Type = type;
            ToHit = toHit;
        }

        public override string ToString()
        {
            return $"{Name}\n" +
                $"1d{DamageDie} {Type} damage\n" +
                $"{(IsTwoHanded? "2 Handed":"1 Handed")}\n" +
                $"{Weight} pounds\n" +
                $"{Description}";
        }
    }
}
