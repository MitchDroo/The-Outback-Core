using NSubstitute;
using NUnit.Framework;
using Outback.Combat;

namespace Outback.Tests.Combat
{
    [TestFixture]
    public class CombatEncounterSystemShould
    {
        private Unit _player;
        private Unit _enemy;
        private ICombatHud _hud;
        private CombatEncounterSystem _system;

        [SetUp]
        public void Setup()
        {
            _player = new Unit();
            _enemy = new Unit()
            {
                Name = "Test"
            };

            _hud = Substitute.For<ICombatHud>();
            _system = new CombatEncounterSystem(_hud);
        }

        [Test]
        public void Initialize_The_Hud_When_Battle_Begins()
        {
            _system.StartBattle(_player, _enemy);

            _hud.Received().Initialize(_player, _enemy);
        }

        [Test]
        public void Display_Dialogue_When_Battle_Begins()
        {
            _system.StartBattle(_player, _enemy);

            _hud.Received().SetDialogueText("A wild Test approaches...");
        }
    }
}