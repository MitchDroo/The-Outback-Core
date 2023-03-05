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
        public void Heal_Unit()
        {
            var unit = new Unit();
            unit.Health = 8;

            var move = new HealMove();
            move.Amount = 2;

            move.Execute(unit);

            unit.Health.Should().Be(10);
        }
    }
}