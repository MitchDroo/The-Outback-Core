using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Outback.Combat;

namespace Outback.Tests.Combat.Core
{
    [TestFixture]
    public class CardSelectOptionShould
    {
        [Test]
        public void Open_Card_Selector_When_Executed()
        {
            var view = Substitute.For<ICardSelectorView>();
            var selector = new CardSelector(view, new List<ICard>());
            var option = new CardSelectOption(selector);

            option.Execute();

            view.Received().Show();
        }
    }
}