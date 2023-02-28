namespace Outback.Combat
{
    public interface ICombatMove
    {
        void Execute();
        void Undo();
    }
}