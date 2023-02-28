using System.Collections.Generic;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using Outback.Combat;

namespace Outback.Tests.Combat
{
    [TestFixture]
    public class CardSelectorShould
    {
        private ICardSelectorView _view;
        private List<ICard> _cards;
        private CardSelector _selector;

        [SetUp]
        public void Setup()
        {
            _view = Substitute.For<ICardSelectorView>();
            _cards = new List<ICard>();
            _selector = new CardSelector(_view, _cards);
        }
        
        [Test]
        public void Show_Ui_When_Open()
        {
            _selector.Open();

            _view.Received().Show();
        }

        [Test]
        public void Pass_Cards_To_Ui_When_Open()
        {
            _selector.Open();

            _view.Received().Cards = _cards;
        }

        [Test]
        public void Warn_Ui_When_No_Card_Selected()
        {
            _view.Selected.ReturnsNull();

            _selector.Open();
            _selector.SelectCard();

            _view.Received().Warn("No card selected!");
        }

        [Test]
        public void Perform_Card_Action_When_Card_Selected()
        {
            var card = Substitute.For<ICard>();
            _view.Selected.Returns(card);

            _selector.Open();
            _selector.SelectCard();

            card.Received().Perform();
        }

        [Test]
        public void Hide_Ui_When_Closed()
        {
            _selector.Close();

            _view.Received().Hide();
        }
    }
}