using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonInterfaces;

namespace DungeonClassLibrary
{
    public sealed class Player : Character, ICombatable
    {
        //fields
        //no fields
        //props
        public byte Level { get; set; }
        public int Experience { get; set; }
        public bool HasRested { get; set; }
        public Races Race { get; set; }
        public Proffessions Proffession { get; set; }
        public int ProficiencyBonus { get; set; }
        public Weapon MainHand { get; set; }
        public Armor WornArmor { get; set; }
        public StatTypes AttackModifier { get; set; }

        //ctors
        public Player(string name, byte[] mainStats, Races race, Proffessions proffession) : base(name, mainStats)
        {
            Level = 1;
            Experience = 0;
            CalculateProficiencyBonus();
            HasRested = false;
            Race = race;
            Proffession = proffession;
            RacialBonus();
            ClassPerks();
            ArmorClass = Convert.ToByte(10 + Modifier(MainStats[1]) + WornArmor.ArmorValue);
        }


        //methods
        public override string ToString()
        {
            return base.ToString() + $"\nLevel: {Level}\n{Race}\n{(HasRested ? "Has rested this level" : "Has not rested this level")} \n\nMain Stats\n-----------------" +
                $"\nStrength - {MainStats[0]}" +
                $"\nDexterity - {MainStats[1]}" +
                $"\nConstitution - {MainStats[2]}" +
                $"\nIntellegence - {MainStats[3]}" +
                $"\nWisdom - {MainStats[4]}" +
                $"\nCharisma - {MainStats[5]}\n";
        }

        public override int MakeAttack()
        {
            return Roll(20) + Modifier(MainStats[(int)AttackModifier]) + ProficiencyBonus;
        }

        public override int DoDamage()
        {
            int dmg = 0;
            switch (Proffession)
            {
                case Proffessions.Fighter:
                    for (int i = 1; i <= MainHand.NbrDamageDie * 2; i++)
                    {
                        dmg += Roll(MainHand.DamageDie);
                    }
                    break;
                case Proffessions.Paladin:
                    dmg += Roll(6);
                    for (int i = 1; i <= MainHand.NbrDamageDie; i++)
                    {
                        dmg += Roll(MainHand.DamageDie);
                    }
                    break;
                case Proffessions.Cleric:
                    for (int i = 1; i <= MainHand.NbrDamageDie; i++)
                    {
                        dmg += Roll(MainHand.DamageDie);
                    }
                    CurrentHealth += (int)Math.Ceiling((double)dmg / 2);
                    break;
                case Proffessions.Rogue:
                    dmg += Roll(6);
                    for (int i = 1; i <= MainHand.NbrDamageDie * 2; i++)
                    {
                        dmg += Roll(MainHand.DamageDie);
                    }
                    break;
                case Proffessions.Barbarian:
                    for (int i = 1; i <= MainHand.NbrDamageDie * 2; i++)
                    {
                        dmg += Roll(MainHand.DamageDie);
                    }
                    break;
                default:
                    break;
            }
            return dmg + Modifier(MainStats[(int)AttackModifier]);
        }

        public bool HasLevelUp()
        {
            #region level checks
            if (Experience >= 300 && Level < 2)
            {
                LevelUp();
                return true;
            }

            if (Experience >= 900 && Level < 3)
            {
                LevelUp();
                return true;
            }

            if (Experience >= 2700 && Level < 4)
            {
                LevelUp();
                return true;
            }

            if (Experience >= 6500 && Level < 5)
            {
                LevelUp();
                return true;
            }

            if (Experience >= 14000 && Level < 6)
            {
                LevelUp();
                return true;
            }

            if (Experience >= 23000 && Level < 7)
            {
                LevelUp();
                return true;
            }

            if (Experience >= 34000 && Level < 8)
            {
                LevelUp();
                return true;
            }

            if (Experience >= 48000 && Level < 9)
            {
                LevelUp();
                return true;
            }

            if (Experience >= 64000 && Level < 10)
            {
                LevelUp();
                return true;
            }

            if (Experience >= 85000 && Level < 11)
            {
                LevelUp();
                return true;
            }

            if (Experience >= 100000 && Level < 12)
            {
                LevelUp();
                return true;
            }

            if (Experience >= 120000 && Level < 13)
            {
                LevelUp();
                return true;
            }

            if (Experience >= 140000 && Level < 14)
            {
                LevelUp();
                return true;
            }

            if (Experience >= 165000 && Level < 15)
            {
                LevelUp();
                return true;
            }

            if (Experience >= 195000 && Level < 16)
            {
                LevelUp();
                return true;
            }

            if (Experience >= 225000 && Level < 17)
            {
                LevelUp();
                return true;
            }

            if (Experience >= 265000 && Level < 18)
            {
                LevelUp();
                return true;
            }

            if (Experience >= 305000 && Level < 19)
            {
                LevelUp();
                return true;
            }

            if (Experience >= 355000 && Level < 20)
            {
                LevelUp();
                return true;
            }
            #endregion

            return false;
        }
        private void LevelUp()
        {
            switch (Proffession)
            {
                case Proffessions.Fighter:
                    MaxHealth += 10 + Modifier(MainStats[2]);
                    break;
                case Proffessions.Paladin:
                    MaxHealth += 10 + Modifier(MainStats[2]);
                    break;
                case Proffessions.Cleric:
                    MaxHealth += 8 + Modifier(MainStats[2]);
                    break;
                case Proffessions.Rogue:
                    MaxHealth += 8 + Modifier(MainStats[2]);
                    break;
                case Proffessions.Barbarian:
                    MaxHealth += 12 + Modifier(MainStats[2]);
                    break;
                default:
                    break;
            }
            Level++;
            CurrentHealth = MaxHealth;
            HasRested = false;
        }

        private void RacialBonus()
        {
            switch (Race)
            {
                case Races.Dwarf:
                    MainStats[2] += 2;
                    break;
                case Races.Elf:
                    MainStats[2] += 2;
                    break;
                case Races.Halfling:
                    MainStats[2] += 2;
                    break;
                case Races.Human:
                    for (int i = 0; i < 6; i++)
                    {
                        MainStats[i]++;
                    }
                    break;
                case Races.Dragonborn:
                    MainStats[0] += 2;
                    MainStats[5]++;
                    break;
                case Races.Gnome:
                    MainStats[3] += 2;
                    break;
                case Races.HalfElf:
                    MainStats[5] += 2;
                    MainStats[0]++; ;
                    MainStats[2]++;
                    break;
                case Races.HalfOrc:
                    MainStats[0] += 2;
                    MainStats[2]++;
                    break;
                case Races.Tiefling:
                    MainStats[5] += 2;
                    MainStats[3]++;
                    break;
            }

        }

        private void ClassPerks()
        {
            switch (Proffession)
            {
                case Proffessions.Fighter:
                    MainHand = new Weapon("Sword", "a short 1 handed sword", 1, 6, DamageType.slashing, false);
                    WornArmor = new Armor("Chain mail", "A vest of linked chains", 3);
                    MaxHealth = 10 + Modifier(MainStats[2]);
                    CurrentHealth = MaxHealth;
                    AttackModifier = StatTypes.Strength;
                    break;
                case Proffessions.Paladin:
                    MainHand = new Weapon("Warhammer", "a large 1 handed hammer", 1, 8, DamageType.bludgeoning, false);
                    MaxHealth = 10 + Modifier(MainStats[2]);
                    WornArmor = new Armor("BreastPlate", "A solid metal chestplate", 4);
                    CurrentHealth = MaxHealth;
                    AttackModifier = StatTypes.Strength;
                    break;
                case Proffessions.Cleric:
                    MainHand = new Weapon("Mace", "a steel mace", 1, 6, DamageType.bludgeoning, false);
                    MaxHealth = 8 + Modifier(MainStats[2]);
                    WornArmor = new Armor("Chain mail", "A vest of linked chains", 3);
                    CurrentHealth = MaxHealth;
                    AttackModifier = StatTypes.Strength;
                    break;
                case Proffessions.Rogue:
                    MainHand = new Weapon("Dagger", "a short iron dagger", 1, 4, DamageType.piercing, false);
                    MaxHealth = 8 + Modifier(MainStats[2]);
                    WornArmor = new Armor("Studded Leather", "A vest made out of Leather with studs covering it", 2);
                    CurrentHealth = MaxHealth;
                    AttackModifier = StatTypes.Dexterity;
                    break;
                case Proffessions.Barbarian:
                    MainHand = new Weapon("club", "a Basic wooden club", 1, 4, DamageType.bludgeoning, false);
                    MaxHealth = 12 + Modifier(MainStats[2]);
                    WornArmor = new Armor("Padded Leather", "A vest made of leather with slight padding", 1);
                    CurrentHealth = MaxHealth;
                    AttackModifier = StatTypes.Strength;
                    break;
                default:
                    break;
            }
        }
        private void CalculateProficiencyBonus()
        {
            ProficiencyBonus = (int)Math.Ceiling((double)Level / 4) + 1;
        }

    }//End Class
}//End Namespace
