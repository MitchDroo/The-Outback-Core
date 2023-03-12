using FluentAssertions;
using NUnit.Framework;
using Outback.Combat;

namespace Outback.Tests.Combat.Core
{
    [TestFixture]
    public class NoCreatureBreedShould
    {
        [Test]
        public void Create_New_Instance()
        {
            var breed = NoCreatureBreed.Instance;

            breed.Should().NotBeNull();
        }

        [Test]
        public void Reuse_Last_Created_Instance()
        {
            var breed = NoCreatureBreed.Instance;
            var newBreed = NoCreatureBreed.Instance;

            newBreed.Should().Be(breed);
        }

        [Test]
        public void Have_Default_Values_Set()
        {
            var breed = NoCreatureBreed.Instance;

            breed.BreedName.Should().Be("No Name");
            breed.StartingHealth.Should().Be(0);
            breed.Attack.Should().Be(0);
            breed.Defense.Should().Be(0);
            breed.Moves.Should().BeEmpty();
        }
    }
}