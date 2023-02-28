using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Outback.Combat;

namespace Outback.Tests.Combat
{
    [TestFixture]
    public class BattleSystemShould
    {
        private IUnitSpawner _playerSpawner;
        private IUnitSpawner _enemySpawner;
        private BattleSystem _battleSystem;

        [SetUp]
        public void Setup()
        {
            _playerSpawner = Substitute.For<IUnitSpawner>();
            _enemySpawner = Substitute.For<IUnitSpawner>();
            _battleSystem = new BattleSystem(_playerSpawner, _enemySpawner);
        }
        
        public class WhenCombatStarts : BattleSystemShould
        {
            [Test]
            public void Spawn_Player_At_First_Position()
            {
                var player = new Player();
                var allies = new List<Ally>()
                {
                    new Ally(),
                    new Ally(),
                    new Ally()
                };
                var enemies = new List<Enemy>()
                {
                    new Enemy(),
                    new Enemy(),
                    new Enemy()
                };

                _battleSystem.StartCombat(player, new CombatEncounter(enemies, allies));

                _playerSpawner.Received().SpawnUnit(player, 0);
            }

            [Test]
            public void Spawn_Allies_At_Correct_Spawn_Positions()
            {
                var player = new Player();
                var allies = new List<Ally>()
                {
                    new Ally(),
                    new Ally(),
                    new Ally()
                };
                var enemies = new List<Enemy>()
                {
                    new Enemy(),
                    new Enemy(),
                    new Enemy()
                };

                _battleSystem.StartCombat(player, new CombatEncounter(enemies, allies));
                
                _playerSpawner.Received().SpawnUnit(allies[0], 1);
                _playerSpawner.Received().SpawnUnit(allies[1], 2);
                _playerSpawner.Received().SpawnUnit(allies[2], 3);
            }

            [Test]
            public void Spawn_Enemies_At_Correct_Spawn_Positions()
            {
                var player = new Player();
                var allies = new List<Ally>()
                {
                    new Ally(),
                    new Ally(),
                    new Ally()
                };
                var enemies = new List<Enemy>()
                {
                    new Enemy(),
                    new Enemy(),
                    new Enemy()
                };

                _battleSystem.StartCombat(player, new CombatEncounter(enemies, allies));

                _enemySpawner.Received().SpawnUnit(enemies[0], 0);
                _enemySpawner.Received().SpawnUnit(enemies[1], 1);
                _enemySpawner.Received().SpawnUnit(enemies[2], 2);
            }
        }
    }
}