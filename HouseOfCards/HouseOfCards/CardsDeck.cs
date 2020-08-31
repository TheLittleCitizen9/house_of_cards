using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HouseOfCards
{
    public class CardsDeck
    {
        public List<Card> Deck;
        public CardsDeck()
        {
            GenerateDeck();
        }

        public void GenerateDeck()
        {
            Deck = new List<Card>();
            int index = 0;
            for (int i = 0; i < 5; i++)
            {
                Deck.Add(new Card(1, (CardColors)index));
                Deck.Add(new Card(1, (CardColors)index));
                Deck.Add(new Card(1, (CardColors)index));

                Deck.Add(new Card(2, (CardColors)index));
                Deck.Add(new Card(2, (CardColors)index));

                Deck.Add(new Card(3, (CardColors)index));
                Deck.Add(new Card(3, (CardColors)index));

                Deck.Add(new Card(4, (CardColors)index));
                Deck.Add(new Card(4, (CardColors)index));

                Deck.Add(new Card(5, (CardColors)index));
                index++;
            }
        }

        public List<Card> GetCardsFromDeck(int numberOfCardsToTake)
        {
            List<Card> playerCards = new List<Card>();
            Random rnd = new Random();
            for (int i = 0; i < numberOfCardsToTake; i++)
            {
                try
                {
                    int index = rnd.Next(0, Deck.Count);
                    playerCards.Add(Deck[index]);
                    Deck.RemoveAt(index);
                }
                catch(ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Cards amount is not enough for all players");
                    throw e;
                }
            }
            return playerCards;
        }

        //public void ShuffleDeck()
        //{
        //    Random rnd = new Random();
        //    Deck = Deck.OrderBy(d => rnd.Next()).ToArray();
        //}
    }
}
