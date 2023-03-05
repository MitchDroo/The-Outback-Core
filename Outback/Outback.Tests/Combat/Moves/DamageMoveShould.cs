using FluentAssertions;
using NUnit.Framework;
using Outback.Combat.Core;
using Outback.Combat.Moves;

namespace Outback.Tests.Combat.Moves
{
    [TestFixture]
    public class DamageMoveShould
    {
        [Test]
        public void Deal_Damage_To_Unit()
        {
            var unit = new Unit();
            unit.Health = 10;

            var move = new DamageMove();
            move.Amount = 2;

            move.Execute(unit);

            unit.Health.Should().Be(8);
        }
    }
}