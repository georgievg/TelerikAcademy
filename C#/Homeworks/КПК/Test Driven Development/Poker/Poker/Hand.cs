using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(params ICard[] cards)
        {
            if (cards.Length > 5)
            {
                throw new ArgumentOutOfRangeException("One hand can not have more than five cards");
            }
            this.Cards = cards.ToList();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var card in this.Cards)
            {
                sb.Append(card.ToString());
            }
            return sb.ToString();
        }
    }
}
