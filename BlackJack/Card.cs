using System;
using System.Linq.Expressions;

namespace BlackJack
{
    
    public enum CardType
    {
        Clubs,
        Diamonds,
        Spades,
        Hearts
    }

    public enum CardFace
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 10,
        Queen = 10,
        King = 10
    }
    public class Card
    {

        public CardType _type;
        public CardFace _face;

        public Card(int type, int face)
        {
            _type = (CardType)type;
            _face = (CardFace)face;
        }

        public Card()
        {

        }

        public override string ToString()
        {
            return ($"{_type}, {_face}");
        }
    }
}