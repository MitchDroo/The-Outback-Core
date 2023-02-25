using FluentAssertions;
using FluentAssertions.Events;
using NUnit.Framework;
using Outback.Combat;

namespace Outback.Tests.Combat
{
    [TestFixture]
    public class HealthShould
    {
        [SetUp]
        public void Setup()
        {
            _health = new Health(1, 2);
            _monitor = _health.Monitor();
        }

        private Health _health;
        private IMonitor<Health> _monitor;

        [Test]
        public void Have_Current_Health_Initialized()
        {
            _health.CurrentHealth.Should().Be(1);
        }

        [Test]
        public void Have_Max_Health_Initialized()
        {
            _health.MaxHealth.Should().Be(2);
        }

        [Test]
        public void Do_Nothing_When_Taking_Zero_Damage()
        {
            _health.TakeDamage(0);

            _health.CurrentHealth.Should().Be(1);
        }

        [Test]
        public void Reduce_Health_When_Taking_Positive_Damage()
        {
            _health.TakeDamage(1);

            _health.CurrentHealth.Should().Be(0);
        }

        [Test]
        public void Ignore_Overkill_When_Taking_Excess_Damage()
        {
            _health.TakeDamage(2);

            _health.CurrentHealth.Should().Be(0);
        }

        [Test]
        public void Do_Nothing_When_Healing_Zero_Health()
        {
            _health.Heal(0);

            _health.CurrentHealth.Should().Be(1);
        }

        [Test]
        public void Heal_When_Healing_Positive_Health()
        {
            _health.Heal(1);

            _health.CurrentHealth.Should().Be(2);
        }

        [Test]
        public void Ignore_OverHealing_When_Healing_Excess_Health()
        {
            _health.Heal(2);

            _health.CurrentHealth.Should().Be(2);
        }

        [Test]
        public void IsDead_Returns_True_When_CurrentHealth_Is_Zero()
        {
            _health.TakeDamage(1);

            _health.IsDead.Should().BeTrue();
        }

        [Test]
        public void IsDead_Returns_False_When_CurrentHealth_Is_Greater_Than_Zero()
        {
            _health.IsDead.Should().BeFalse();
        }

        [Test]
        public void Invoke_OnHealthUpdated_Event_When_Taking_Damage()
        {
            var num = -1;
            _health.OnHealthUpdated += i => num = i;
            
            _health.TakeDamage(0);

            num.Should().Be(0);
        }

        [Test]
        public void Invoke_OnHealthUpdated_Event_When_Healing()
        {
            var num = -1;
            _health.OnHealthUpdated += i => num = i;
            
            _health.Heal(0);

            num.Should().Be(0);
        }
    }
}