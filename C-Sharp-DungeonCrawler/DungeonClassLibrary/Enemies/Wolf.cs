using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonClassLibrary.Enemies
{
     public class Wolf : Enemy
    {
        public int PackSize { get; set; }
        public Wolf()
        {
            Name = "Wolf";
            Stats = new byte[] {12, 15, 12, 3, 12, 6 };
            ChallengeRating = .25;
            DamageDie = 4;
            NbrDamageDie = 2;
            DamageModifier = DungeonClassLibrary.Stats.Dexterity;
            Description = "Wild wolf";
            PackSize = 1;
        }

    }
}
