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
    }

    public class Weapon : Item
    {
        public Roll Damage { get; set; }
    }

    public class Armor : Item
    {

    }
}
