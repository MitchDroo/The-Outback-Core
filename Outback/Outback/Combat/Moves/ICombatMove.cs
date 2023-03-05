using Outback.Combat.Core;

namespace Outback.Combat.Moves
{
    public interface ICombatMove
    {
        void Execute(Unit unit);
    }
}