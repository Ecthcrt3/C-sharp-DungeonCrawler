using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonMethodLibrary;

namespace DungeonClassLibrary
{
    public class Enemy : Character
    {
        public double ChallengeRating { get; set; }
        public string Description { get; set; }
        public int DamageDie { get; set; }
        public int NbrDamageDie { get; set; }
        public Stats DamageModifier { get; set; }

        public Enemy()
        {
        }

        public Enemy(string name, byte[] stats, double cr, int damageDie, int nbrDamageDie, Stats damageModifier, string description):base(name, stats)
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

        public override int Attack()
        {
            return UI.Roll(20) + Stats[(int)DamageModifier];
        }

        public override int Damage()
        {
            int total = 0;
            for (int i = 0; i < NbrDamageDie; i++)
            {
                total += UI.Roll(DamageDie) + (int)DamageModifier;
            }
            return total;
        }
    }
}
