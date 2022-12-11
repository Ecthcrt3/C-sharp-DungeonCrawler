using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonClassLibrary
{
    public abstract class Enemy : Character
    {
        public double ChallengeRating { get; set; }
        public string Description { get; set; }
        public int DamageDie { get; set; }
        public int NbrDamageDie { get; set; }
        public StatTypes DamageModifier { get; set; }
        public int XpReward { get; set; }
        public Enemy()
        {
        }

        public Enemy(string name, byte[] stats, double cr, int damageDie, int nbrDamageDie, StatTypes damageModifier, string description):base(name, stats)
        {
            ChallengeRating = cr;
            DamageDie = damageDie;
            NbrDamageDie = nbrDamageDie;
            DamageModifier = damageModifier;
            Description = description;
        }

        public override string ToString()
        {
            return base.ToString() + $"{ChallengeRating} cr \n" +
                $"{Description}";
        }

        public override int MakeAttack()
        {
            return Roll(20) + (Stats[(int)DamageModifier] - 10) / 2;
        }

        public override int DoDamage()
        {
            int dmg = 0;
            for(int i = 1; i <= NbrDamageDie; i++)
            {
                dmg += Roll(DamageDie);
            }
            return dmg;
        }
    }
}
