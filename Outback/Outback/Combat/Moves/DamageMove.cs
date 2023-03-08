using Outback.Combat.Core;

namespace Outback.Combat.Moves
{
    public class DamageMove : ICombatMove
    {
        private Unit _target;
        
        public int Amount;

        public void Execute(Unit unit)
        {
            _target = unit;
            _target.TakeDamage(Amount);
        }

        public void Undo()
        {
            _target.Heal(Amount);
        }
    }
}