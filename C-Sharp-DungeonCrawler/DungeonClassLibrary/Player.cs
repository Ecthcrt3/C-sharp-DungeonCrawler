using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonClassLibrary
{
    public sealed class Player : Character
    {
        public Races Race { get; set; }
        public Proffessions Proffession { get; set; }
        public List<Item> Inventory {  get; set; }
        public int Level { get; set; }
        public Weapon MainHand { get; set; }

        //Ctors
        public Player(string name)
        {
            Name = name;
            this.Stats = new byte[] { 10,10,10,10,10,10 };
            MaxHealth = 10 + (Stats[2] / 2 - 10);
            CurrentHealth = MaxHealth;
            Level = 1;
            Race = Races.Dwarf;
            Proffession = Proffessions.Paladin;
        }
        public Player(string name, byte[]stats, Races race, Proffessions proffession):base(name, stats)
        {
            Race = race;
            Proffession = proffession;
            Level = 1;
            ProffessionBonus(proffession);
            RaceBonus(race);
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

        private void ProffessionBonus(Proffessions proffession)
        {
            switch (proffession)
            {
                case Proffessions.Fighter:
                case Proffessions.Paladin:
                case Proffessions.Bard:
                    MainHand = new Weapon(001, "Sword", 7, "A shortsword for the new adventurer", 6, false, DamageType.piercing, 1);
                    break;
                case Proffessions.Wizard:
                case Proffessions.Sorcerer:
                case Proffessions.Warlock:
                    MainHand = new Weapon(002, "Staff", 6, "A beginer staff to channel spells", 6, false, DamageType.bludgeoning, 1);
                    break;
                case Proffessions.Cleric:
                    MainHand = new Weapon(003, "Mace", 4, "A solid mace carried by new clerics", 6, false, DamageType.bludgeoning, 1);
                    break;
                case Proffessions.Rogue:
                    MainHand = new Weapon(004, "Dagger", 2, "A shortsword for the new adventurer", 4, false, DamageType.piercing, 1);
                    break;
                case Proffessions.Barbarian:
                    MainHand = new Weapon(001, "Axe", 8, "A shortsword for the new adventurer", 8, false, DamageType.slashing, 1);
                    break;
            }
        }

        private void RaceBonus(Races race)
        {
            switch (race)
            {
                case Races.Dwarf:
                    break;
                case Races.Elf:
                    break;
                case Races.Halfling:
                    break;
                case Races.Human:
                    break;
                case Races.Dragonborn:
                    break;
                case Races.Gnome:
                    break;
                case Races.HalfElf:
                    break;
                case Races.HalfOrc:
                    break;
                case Races.Tiefling:
                    break;
            }
        }
    }
}
