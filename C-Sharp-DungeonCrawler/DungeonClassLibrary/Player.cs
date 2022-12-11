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


        //ctors
        public Player(string name, byte armorClass, byte[] mainStats) : base(name, armorClass, mainStats)
        {
            Level = 1;
            Experience = 0;
            MaxHealth = 10 + mainStats[2];
            CurrentHealth = 10;
            HasRested = false;
        }


        //methods
        public override string ToString()
        {
            return base.ToString() + $"\nLevel: {Level}\n{(HasRested ? "Has rested this level" : "Has not rested this level")} \n\nMain Stats\n-----------------" +
                $"\nStrength - {MainStats[0]}" +
                $"\nDexterity - {MainStats[1]}" +
                $"\nConstitution - {MainStats[2]}" +
                $"\nIntellegence - {MainStats[3]}" +
                $"\nWisdom - {MainStats[4]}" +
                $"\nCharisma - {MainStats[5]}\n";
        }

        public override int MakeAttack()
        {
            return Roll(20) + MainStats[0];
        }

        public override int DoDamage()
        {
            return Roll(8) + MainStats[0];
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
            Level++;
            MaxHealth += 10;
            CurrentHealth = MaxHealth;
            HasRested = false;
        }

    }//End Class
}//End Namespace
