using System;
using System.Collections.Generic;
using System.Text;

namespace HouseOfCards
{
    public class Player
    {
        public string Name { get; private set; }
        public List<Card> Cards { get; set; }

        public Player(string name)
        {
            Name = name;
            Cards = new List<Card>();
        }

        public void ShowCards()
        {
            Console.Write($"Player {Name}: ");
            foreach (var card in Cards)
            {
                Console.Write($"{card.Number} - {card.Color} \t");
            }
            Console.WriteLine();
        }

        public void ShowRandomCard()
        {
            Random rnd = new Random();
            Console.WriteLine($"{Cards[rnd.Next(5)].Number} - {Cards[rnd.Next(5)].Color}");
        }
    }
}
