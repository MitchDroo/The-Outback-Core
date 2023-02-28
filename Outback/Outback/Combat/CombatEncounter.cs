using System.Collections.Generic;

namespace Outback.Combat
{
    public class CombatEncounter
    {
        public CombatEncounter(List<Enemy> enemies, List<Ally> allies)
        {
            Enemies = enemies;
            Allies = allies;
        }

        public List<Enemy> Enemies { get; }
        public List<Ally> Allies { get; }
    }
}