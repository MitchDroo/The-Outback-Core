using System.Collections.Generic;

namespace Outback.Combat
{
    public interface ICardSelectorView
    {
        void Show();
        void Hide();
        List<ICard> Cards { set; }
        ICard Selected { get; }
        void Warn(string text);
    }
}