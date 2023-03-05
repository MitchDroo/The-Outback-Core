using Outback.Combat.Core;

namespace Outback.Combat.Moves
{
    public class HealMove : ICombatMove
    {
        public int Amount;

        public void Execute(Unit unit)
        {
            unit.Heal(Amount);
        }
    }
}