using System;
using System.Collections.Generic;
using System.Text;

namespace HouseOfCards
{
    public class MenuDisplayer
    {
        public void PrintMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1 - Show Other Players Cards");
            Console.WriteLine("2 - Play Card");
            Console.WriteLine("3 - Get Clue");
            Console.WriteLine("4 - Throw Card");
        }
    }
}
