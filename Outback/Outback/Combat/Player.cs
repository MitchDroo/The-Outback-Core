using System.Collections.Generic;

namespace Outback.Combat
{
    public class Player
    {
        private readonly List<Card> _deck;

        public Player()
        {
            _deck = new List<Card>();
        }

        public IEnumerable<Card> Deck => _deck;

        public void Collect(Card card)
        {
            _deck.Add(card);
        }

        public void Remove(Card card)
        {
            _deck.Remove(card);
        }
    }
}