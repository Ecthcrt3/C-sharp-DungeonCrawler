using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonClassLibrary.Enemies
{
    public sealed class Wolf : Enemy
    {
        public int PackSize { get; set; }
        public Wolf()
        {
            Name = "Wolf";
            MainStats = new byte[] { 12, 15, 12, 3, 12, 6 };
            ChallengeRating = 1;
            MaxHealth = 10;
            PackSize = 1;
            ArmorClass = 13;
            XpReward = 50;
        }


    }
}
