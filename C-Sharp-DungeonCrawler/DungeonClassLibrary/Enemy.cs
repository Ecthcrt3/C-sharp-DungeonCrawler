using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonInterfaces;

namespace DungeonClassLibrary
{
    public abstract class Enemy : Character , ICombatable
    {
        //props
        public byte ChallengeRating { get; set; }
        public int XpReward { get; set; }

        //ctors
        public Enemy() { }

        public Enemy(string name, byte armorClass, byte[] mainStats, byte challengRating, int xpReward ):base(name, armorClass, mainStats)
        {
            ChallengeRating = challengRating;
            XpReward = xpReward;
        }

        //methods
        public void LevelScaling(int level)
        {
            double multiplier = (double)level/ChallengeRating;
            MaxHealth = (int)Math.Ceiling((double)MaxHealth * multiplier);
            CurrentHealth = MaxHealth;
            XpReward = (int)Math.Ceiling((double)XpReward * multiplier);
        }
        public override int MakeAttack()
        {
            return Roll(20) + MainStats[0];
        }

        public override int DoDamage()
        {
            return Roll(6);
        }
    }//End Class
}//End Namespace
