using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonClassLibrary;

namespace DungeonClassLibrary.Enemies
{
    public sealed class Goblin : Enemy
    {
        public bool IsStrong { get; set; }
        public Goblin()
        {
            Name = "Goblin";
            this.Stats = new byte[] { 8, 14, 10, 10, 8, 8 };
            ChallengeRating = 1;
            DamageDie = 6;
            NbrDamageDie = 1;
            DamageModifier = DungeonClassLibrary.StatTypes.Dexterity;
            Description = "Small evil humanoid thats strength lies in numbers";
            MaxHealth = 7;
            CurrentHealth = MaxHealth;
            IsStrong = false;
            ArmorClass = 15;
            XpReward = 50;
        }
    }
}
