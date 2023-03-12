using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Outback.Combat;
using Outback.Combat.Core;

namespace Outback.Tests.Combat.Core
{
    [TestFixture]
    public class BattleSystemShould
    {
        private IUnitSpawner _playerSpawner;
        private IUnitSpawner _enemySpawner;
        private BattleSystem _battleSystem;
        private ICombatHud _hud;

        [SetUp]
        public void Setup()
        {
            _playerSpawner = Substitute.For<IUnitSpawner>();
            _enemySpawner = Substitute.For<IUnitSpawner>();
            _hud = Substitute.For<ICombatHud>();
            _battleSystem = new BattleSystem(_playerSpawner, _enemySpawner, _hud);
        }
        
        public class WhenCombatStarts : BattleSystemShould
        {
            [Test]
            public void Spawn_Player_At_First_Position()
            {
                var player = new Unit();
                var allies = new List<Unit>()
                {
                    new Unit(),
                    new Unit(),
                    new Unit()
                };
                var enemies = new List<Unit>()
                {
                    new Unit(),
                    new Unit(),
                    new Unit()
                };

                _battleSystem.StartCombat(player, new CombatEncounter(enemies, allies));

                _playerSpawner.Received().SpawnUnit(player, 0);
            }

            [Test]
            public void Spawn_Allies_At_Correct_Spawn_Positions()
            {
                var player = new Unit();
                var allies = new List<Unit>()
                {
                    new Unit(),
                    new Unit(),
                    new Unit()
                };
                var enemies = new List<Unit>()
                {
                    new Unit(),
                    new Unit(),
                    new Unit()
                };

                _battleSystem.StartCombat(player, new CombatEncounter(enemies, allies));
                
                _playerSpawner.Received().SpawnUnit(allies[0], 1);
                _playerSpawner.Received().SpawnUnit(allies[1], 2);
                _playerSpawner.Received().SpawnUnit(allies[2], 3);
            }

            [Test]
            public void Spawn_Enemies_At_Correct_Spawn_Positions()
            {
                var player = new Unit();
                var allies = new List<Unit>()
                {
                    new Unit(),
                    new Unit(),
                    new Unit()
                };
                var enemies = new List<Unit>()
                {
                    new Unit(),
                    new Unit(),
                    new Unit()
                };

                _battleSystem.StartCombat(player, new CombatEncounter(enemies, allies));

                _enemySpawner.Received().SpawnUnit(enemies[0], 0);
                _enemySpawner.Received().SpawnUnit(enemies[1], 1);
                _enemySpawner.Received().SpawnUnit(enemies[2], 2);
            }
            
            [Test]
            public void Initialize_The_Hud_When_Battle_Begins()
            {
                var player = new Unit();
                var allies = new List<Unit>()
                {
                    new Unit(),
                    new Unit(),
                    new Unit()
                };
                var enemies = new List<Unit>()
                {
                    new Unit(),
                    new Unit(),
                    new Unit()
                };

                _battleSystem.StartCombat(player, new CombatEncounter(enemies, allies));

                _hud.Received().Initialize(player, enemies[0]);
            }

            [Test]
            public void Display_Dialogue_When_Battle_Begins()
            {
                var player = new Unit();
                var allies = new List<Unit>()
                {
                    new Unit(),
                    new Unit(),
                    new Unit()
                };
                var enemies = new List<Unit>()
                {
                    new Unit()
                    {
                        Name = "Test"
                    },
                    new Unit(),
                    new Unit()
                };

                _battleSystem.StartCombat(player, new CombatEncounter(enemies, allies));

                _hud.Received().SetDialogueText("A wild Test approaches...");
            }
        }
    }
}