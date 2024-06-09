using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BlackJack
{
    public class Generator
    {
        private Random _rnd = new Random();
        public List<Card> Deck = new List<Card>();
        private int _CardFacesAmount = CardFace.GetNames(typeof(CardFace)).Length;
        private int _cardTypesAmount = CardType.GetNames(typeof(CardType)).Length;

        public Generator(Random rnd)
        {
            _rnd = rnd;
        }

        public Generator()
        {

        }

        public void Init(int deckAmount)
        {
            for (int x = 0; x < deckAmount; x++)
            {
                for (int i = 0; i < _cardTypesAmount; i++)
                {
                    for (int j = 0; j < _CardFacesAmount; j++)
                    {
                        Card newCard = new Card(i, j);
                        Deck.Add(newCard);
                    }
                }
            }
        }

        public Card Draw()
        {
            int index = _rnd.Next(Deck.Count);
            Card drawn = Deck[index];
            Deck.RemoveAt(index);
            return drawn;
        }

    }
}