using System;
using System.Collections.Generic;
using System.Text;

namespace HouseOfCards
{
    public class Player
    {
        public string Name { get; private set; }
        public Card[] Cards { get; set; }

        public Player(string name)
        {
            Name = name;
            Cards = new Card[5];
        }

        public void ShowCards()
        {
            foreach (var card in Cards)
            {
                Console.Write($"{card.Number} - {card.Color} \t");
            }
        }

        public void ShowRandomCard()
        {
            Random rnd = new Random();
            Console.WriteLine($"{Cards[rnd.Next(5)].Number} - {Cards[rnd.Next(5)].Color}");
        }
    }
}
