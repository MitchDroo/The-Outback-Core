using System.Collections.Generic;

namespace Outback.Combat.Core
{
    public class CombatEncounter
    {
        public CombatEncounter(List<Unit> enemies, List<Unit> allies)
        {
            Enemies = enemies;
            Allies = allies;
        }

        public List<Unit> Enemies { get; }
        public List<Unit> Allies { get; }
    }
}