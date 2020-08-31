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
    }
}
