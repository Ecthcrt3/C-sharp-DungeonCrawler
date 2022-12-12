using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonClassLibrary
{
    public class Armor : Item
    {
        public int ArmorValue { get; set; }

        public Armor(string name, string description, int armorValue): base(name, description)
        {
            ArmorValue = armorValue;
        }
    }
}
