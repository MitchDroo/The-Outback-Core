using Outback.Combat.Core;

namespace Outback.Combat.Moves
{
    public class HealMove : ICombatMove
    {
        public int Amount;

        private Unit _target;

        public void Execute(Unit unit)
        {
            _target = unit;
            _target.Heal(Amount);
        }

        public void Undo()
        {
            _target.TakeDamage(Amount);
        }
    }
}