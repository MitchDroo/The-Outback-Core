using Outback.Combat.Core;

namespace Outback.Combat.Moves
{
    public class DamageMove : ICombatMove
    {
        public int Amount;

        public void Execute(Unit unit)
        {
            unit.TakeDamage(Amount);
        }
    }
}