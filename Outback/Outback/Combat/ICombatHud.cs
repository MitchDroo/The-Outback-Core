namespace Outback.Combat
{
    public interface ICombatHud
    {
        void Initialize(Unit player, Unit enemy);
        void SetDialogueText(string text);
    }
}