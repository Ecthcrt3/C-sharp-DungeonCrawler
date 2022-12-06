using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonInterfaces
{
    public class CombatManager
    {
        public static bool CalculateHit(ICombatable attacker, ICombatable target)
        {

            return attacker.MakeAttack() >= target.GetAC();

        }
        public static int CalculateDamage(ICombatable attacker, ICombatable target)
        {
            int dmg = attacker.DoDamage();
            target.TakeDamage(dmg);
            return dmg;
        }
    }
}
