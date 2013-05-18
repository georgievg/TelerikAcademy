using System;

namespace Poker
{
    public class Card : ICard,IComparable
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            string face = GetCardFace();
            string suit = GetCardSuit();
            string finalCard = face + suit;
            return finalCard;
        }

        private string GetCardFace()
        {
            string face;
            if ((int)this.Face <= 10)
            {
                face = ((int)this.Face).ToString();
            }
            else
            {
                char letter = this.Face.ToString()[0];
                face = letter.ToString();
            }
            return face;
        }

        private string GetCardSuit()
        {
            char suit;
            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    {
                        suit = '♣';
                        break;
                    }
                case CardSuit.Diamonds:
                    {
                        suit = '♦';
                        break;
                    }
                case CardSuit.Hearts:
                    {
                        suit = '♥';
                        break;
                    }
                case CardSuit.Spades:
                    {
                        suit = '♠';
                        break;
                    }
                default:
                    throw new ArgumentException(this.Suit + " is not a valid card suit");
            }
            return suit.ToString();
        }
        
        public int CompareTo(object other)
        {
            int thisFace = (int)this.Face;
            int otherFace = (int)((other as Card).Face);
            if (thisFace > otherFace)
            {
                return 1;               
            }
            if (thisFace == otherFace)
            {
                return 0;
            }
            return -1;
        }
    }
}
