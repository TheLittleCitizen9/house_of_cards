using System;
using System.Collections.Generic;
using System.Text;

namespace HouseOfCards
{
    public class Card
    {
        public int Number { get; set; }
        public CardColors Color { get; set; }

        public Card(int number, CardColors cardColor)
        {
            Number = number;
            Color = cardColor;
        }
    }
}
