using System.Collections.Generic;

namespace Outback.Combat.Core
{
    public class BattleSystem
    {
        private readonly IUnitSpawner _playerSpawner;
        private readonly IUnitSpawner _enemySpawner;
        private readonly ICombatHud _hud;

        public BattleSystem(IUnitSpawner playerSpawner, IUnitSpawner enemySpawner, ICombatHud hud)
        {
            _playerSpawner = playerSpawner;
            _enemySpawner = enemySpawner;
            _hud = hud;
        }

        public void StartCombat(Unit player, CombatEncounter combatEncounter)
        {
            SpawnPlayer(player);
            SpawnAllies(combatEncounter.Allies);
            SpawnEnemies(combatEncounter.Enemies);
            _hud.Initialize(player, combatEncounter.Enemies[0]);
            _hud.SetDialogueText($"A wild {combatEncounter.Enemies[0].Name} approaches...");
        }

        private void SpawnPlayer(Unit player)
        {
            _playerSpawner.SpawnUnit(player, 0);
        }

        private void SpawnAllies(List<Unit> allies)
        {
            for (var i = 0; i < allies.Count; i++)
            {
                _playerSpawner.SpawnUnit(allies[i], i + 1);
            }
        }

        private void SpawnEnemies(List<Unit> enemies)
        {
            for (var i = 0; i < enemies.Count; i++)
            {
                _enemySpawner.SpawnUnit(enemies[i], i);
            }
        }
    }
}