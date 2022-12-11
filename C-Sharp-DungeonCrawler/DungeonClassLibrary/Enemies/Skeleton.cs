using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonClassLibrary.Enemies
{
    public sealed class Skeleton : Enemy
    {
        public bool IsArmored { get; set; }

        public Skeleton()
        {
            Name = "Skeleton";
            Stats = new byte[] { 10, 14, 15, 6, 8, 5};
            ChallengeRating = 1;
            DamageDie = 6;
            NbrDamageDie = 1;
            DamageModifier = DungeonClassLibrary.StatTypes.Dexterity;
            Description = "A living skelton!";
            IsArmored = false;
            MaxHealth = 13;
            CurrentHealth = MaxHealth;
            ArmorClass = 13;
            XpReward = 50;
        }
    }
}
