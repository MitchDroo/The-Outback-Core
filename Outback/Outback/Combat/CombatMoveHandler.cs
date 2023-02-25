using System.Collections.Generic;

namespace Outback.Combat
{
    public class CombatMoveHandler
    {
        private readonly Stack<ICombatMove> _moves;

        public CombatMoveHandler()
        {
            _moves = new Stack<ICombatMove>();
        }

        public void Record(ICombatMove combatMove)
        {
            _moves.Push(combatMove);
            combatMove.Execute();
        }

        public void Rewind()
        {
            if (IsEmpty()) return;
            var combatMove = _moves.Pop();
            combatMove.Undo();
        }

        public bool IsEmpty()
        {
            return _moves.Count == 0;
        }
    }
}