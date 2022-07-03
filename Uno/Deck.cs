using System;
using System.Collections.Generic;
using System.Linq;

namespace Uno
{
    public class Deck
    {
        private List<Card> _cards = new List<Card>();

        public int Count => _cards.Count;

        public Deck()
        {
            foreach (Color color in Enum.GetValues(typeof(Color)))
            {
                for (int i = 0; i < 9; i++)
                {
                    int index = i;
                    _cards.Add(new Card(color, index));
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            _cards = _cards.OrderBy(_ => random.Next()).ToList();
        }

        public Card DrawCard()
        {
            Card card = _cards[0];
            _cards.Remove(card);
            return card;
        }

        public Deck AddCards(List<Card> cards)
        {
            _cards.AddRange(cards);
            return this;
        }
    }
}