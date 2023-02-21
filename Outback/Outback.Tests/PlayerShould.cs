using FluentAssertions;
using NUnit.Framework;
using Outback.Combat;

namespace Outback.Tests
{
    [TestFixture]
    public class PlayerShould
    {
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _player = new Player();
        }

        [Test]
        public void Start_With_An_Empty_Deck()
        {
            _player.Deck.Should().BeEmpty();
        }

        [Test]
        public void Add_Card_To_Deck_When_Card_Is_Collected()
        {
            var card = new Card("A Card", "A Description");

            _player.Collect(card);

            _player.Deck.Should().Contain(card);
        }

        [Test]
        public void Remove_Card_From_Deck_When_Card_Is_Removed()
        {
            var card = new Card("A Card", "A Description");

            _player.Collect(card);

            _player.Remove(card);
        }
    }
}