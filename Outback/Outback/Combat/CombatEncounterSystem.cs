namespace Outback.Combat
{
    public class CombatEncounterSystem
    {
        private readonly ICombatHud _hud;
        
        public CombatEncounterSystem(ICombatHud hud)
        {
            _hud = hud;
        }

        public void StartBattle(Unit player, Unit enemy)
        {
            _hud.Initialize(player, enemy);
            _hud.SetDialogueText($"A wild {enemy.Name} approaches...");
        }
    }
}