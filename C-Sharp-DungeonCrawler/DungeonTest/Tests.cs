using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonClassLibrary;
//using DungeonMethodLibrary;

namespace DungeonTest
{
    internal class Tests
    {
        static void Main(string[] args)
        {
            Character c1 = new Character("Testy", new byte[] { 10, 10, 10, 10, 10, 10 });
            Console.WriteLine(c1);
            Item i1 = new Item(001, "Sword of Testing", 25, "This Sword will be used to test our code out!");
            Console.WriteLine(i1);
            Console.WriteLine("");
            Weapon w1 = new Weapon(001, "Sword of Testing", 25, "This Sword will be used to test our code out!", 6, true, DamageType.slashing, 0);
            Console.WriteLine(w1);
            Console.WriteLine("");
            Console.ReadLine();
            Enemy e1 = new Enemy("Training dummy", new byte[] { 10, 10, 10, 10, 10, 10 }, 0, 4, 1, Stats.Strength, "A punching bag that punches back");
            Console.WriteLine(e1);
            Console.WriteLine(e1.Attack());
           // Player p1 = UI.CreatePlayer();
            //Console.WriteLine(p1);
        }
    }
}
