using FluentAssertions;
using NUnit.Framework;
using Outback.Combat;

namespace Outback.Tests.Combat
{
    [TestFixture]
    public class CreatureShould
    {
        [Test]
        public void Have_Breed_Set()
        {
            var breed = new CreatureBreed();
            var creature = new Creature(breed);

            creature.Breed.Should().Be(breed);
        }

        [Test]
        public void Have_Health_Set()
        {
            var breed = new CreatureBreed()
            {
                StartingHealth = 10
            };
            var creature = new Creature(breed);

            creature.Health.Should().NotBeNull();
            creature.Health.CurrentHealth.Should().Be(10);
            creature.Health.MaxHealth.Should().Be(10);
        }

        [Test]
        public void Use_Null_Breed_If_No_Breed_Is_Set()
        {
            var creature = new Creature(null);

            creature.Breed.Should().Be(NoCreatureBreed.Instance);
        }
    }
}