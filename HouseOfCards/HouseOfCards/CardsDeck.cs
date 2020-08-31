using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HouseOfCards
{
    public class CardsDeck
    {
        public Card[] Deck;
        public CardsDeck()
        {
            GenerateDeck();
        }

        public void GenerateDeck()
        {
            Deck = new Card[50];
            int index = 0;
            for (int i = 0; i < 5; i++)
            {
                Deck[index] = new Card(1, (CardColors)index);
                Deck[index] = new Card(1, (CardColors)index);
                Deck[index] = new Card(1, (CardColors)index);

                Deck[index] = new Card(2, (CardColors)index);
                Deck[index] = new Card(2, (CardColors)index);

                Deck[index] = new Card(3, (CardColors)index);
                Deck[index] = new Card(3, (CardColors)index);

                Deck[index] = new Card(4, (CardColors)index);
                Deck[index] = new Card(4, (CardColors)index);

                Deck[index] = new Card(5, (CardColors)index);
            }
        }

        public Card[] GetCardsFromDeck(int numberOfCardsToTake)
        {
            Card[] cards = Deck.Take(numberOfCardsToTake).ToArray();
            Deck = Deck.Where(d => !cards.Contains(d)).ToArray();
            return cards;
        }

        public void ShuffleDeck()
        {
            Random rnd = new Random();
            Deck = Deck.OrderBy(d => rnd.Next()).ToArray();
        }
    }
}
