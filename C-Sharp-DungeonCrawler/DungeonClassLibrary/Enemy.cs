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
        public override int MakeAttack()
        {
            return Roll(20) + MainStats[0];
        }

        public override int DoDamage()
        {
            return Roll(6);
        }
    }

    //public abstract class Enemy : Character
    //{
    //    public double ChallengeRating { get; set; }
    //    public string Description { get; set; }
    //    public int DamageDie { get; set; }
    //    public int NbrDamageDie { get; set; }
    //    public StatTypes DamageModifier { get; set; }
    //    public int XpReward { get; set; }
    //    public Enemy()
    //    {
    //    }

    //    public Enemy(string name, byte[] stats, double cr, int damageDie, int nbrDamageDie, StatTypes damageModifier, string description, byte armorClass):base(name,armorClass ,stats)
    //    {
    //        ChallengeRating = cr;
    //        DamageDie = damageDie;
    //        NbrDamageDie = nbrDamageDie;
    //        DamageModifier = damageModifier;
    //        Description = description;
    //    }

    //    public override string ToString()
    //    {
    //        return base.ToString() + $"{ChallengeRating} cr \n" +
    //            $"{Description}";
    //    }

    //    public override int MakeAttack()
    //    {
    //        return Roll(20) + (Stats[(int)DamageModifier] - 10) / 2;
    //    }

    //    public override int DoDamage()
    //    {
    //        int dmg = 0;
    //        for(int i = 1; i <= NbrDamageDie; i++)
    //        {
    //            dmg += Roll(DamageDie);
    //        }
    //        return dmg;
    //    }
    //}
}
