using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonClassLibrary
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public string Description { get; set; }

        public Item(int id, string name, int weight, string description)
        {
            ID = id;
            Name = name;
            Weight = weight;
            Description = description;
        }

        public override string ToString()
        {
            return ($"{Name}\n" +
                $"{Weight} Pounds\n" +
                $"{Description}");
        }
    }
}
