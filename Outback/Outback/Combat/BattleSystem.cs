using System.Collections.Generic;

namespace Outback.Combat
{
    public class BattleSystem
    {
        private readonly IUnitSpawner _playerSpawner;
        private readonly IUnitSpawner _enemySpawner;

        public BattleSystem(IUnitSpawner playerSpawner, IUnitSpawner enemySpawner)
        {
            _playerSpawner = playerSpawner;
            _enemySpawner = enemySpawner;
        }

        public void StartCombat(Player player, CombatEncounter combatEncounter)
        {
            SpawnPlayer(player);
            SpawnAllies(combatEncounter.Allies);
            SpawnEnemies(combatEncounter.Enemies);
        }

        private void SpawnPlayer(Player player)
        {
            _playerSpawner.SpawnUnit(player, 0);
        }

        private void SpawnAllies(List<Ally> allies)
        {
            for (var i = 0; i < allies.Count; i++)
            {
                _playerSpawner.SpawnUnit(allies[i], i + 1);
            }
        }

        private void SpawnEnemies(List<Enemy> enemies)
        {
            for (var i = 0; i < enemies.Count; i++)
            {
                _enemySpawner.SpawnUnit(enemies[i], i);
            }
        }
    }
}