using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonClassLibrary.Enemies
{
    public sealed class Spider : Enemy
    {
        public bool IsVenemous { get; set; }

        public Spider()
        {
            Name = "Spider";
            Stats = new byte[] { 14, 16, 12, 2, 11, 4};
            ChallengeRating = 1;
            DamageDie = 8;
            NbrDamageDie = 1;
            DamageModifier = DungeonClassLibrary.StatTypes.Dexterity;
            Description = "A giant Spider";
            IsVenemous = false;
        }
    }
}
