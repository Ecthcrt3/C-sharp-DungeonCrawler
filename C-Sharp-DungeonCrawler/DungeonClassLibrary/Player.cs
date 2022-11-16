using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonClassLibrary
{
    public class Player : Character
    {
        public Races Race { get; set; }
        public Proffessions Proffession { get; set; }
        public List<Item> Inventory {  get; set; }
        public int Level { get; set; }


        //Ctors
        public Player(string name, byte[]stats, Races race, Proffessions proffession):base(name, stats)
        {
            Race = race;
            Proffession = proffession;
            Level = 1;
        }


        //Methods
        public override string ToString()
        {
            return ($"Name: {Name}\n" +
                $"Level: {Level}\n" +
                $"Race: {Race}\n" +
                $"Proffession: {Proffession}\n" +
                $"Current Health: {CurrentHealth}/{MaxHealth}\n\n" +
                $"--Stats--\n" +
                $"Strength: {Stats[0]}\n" +
                $"Dexterity: {Stats[1]}\n" +
                $"Constitution: {Stats[2]}\n" +
                $"Intellegence: {Stats[3]}\n" +
                $"Wisdom: {Stats[4]}\n" +
                $"Charisma: {Stats[5]}\n");
        }
    }
}
