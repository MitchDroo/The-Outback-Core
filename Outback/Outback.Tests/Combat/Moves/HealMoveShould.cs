using FluentAssertions;
using NUnit.Framework;
using Outback.Combat.Core;
using Outback.Combat.Moves;

namespace Outback.Tests.Combat.Moves
{
    [TestFixture]
    public class HealMoveShould
    {
        [Test]
        public void Heal_Unit_When_Executed()
        {
            var unit = new Unit();
            unit.Health = 8;

            var move = new HealMove();
            move.Amount = 2;

            move.Execute(unit);

            unit.Health.Should().Be(10);
        }

        [Test]
        public void Revert_Health_When_Undone()
        {
            var unit = new Unit();
            unit.Health = 8;

            var move = new HealMove();
            move.Amount = 2;

            move.Execute(unit);

            move.Undo();

            unit.Health.Should().Be(8);
        }
    }
}