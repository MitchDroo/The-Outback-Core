using System.Collections.Generic;

namespace Outback.Combat
{
    public class CardSelector
    {
        private readonly ICardSelectorView _view;
        private readonly List<ICard> _cards;

        public CardSelector(ICardSelectorView view, List<ICard> cards)
        {
            _view = view;
            _cards = cards;
        }
        
        public void Open()
        {
            _view.Cards = _cards;
            _view.Show();
        }

        public void Close()
        {
            _view.Hide();
        }

        public void SelectCard()
        {
            if (_view.Selected == null)
            {
                _view.Warn("No card selected!");
                return;
            }
            _view.Selected.Perform();
        }
    }
}