using System;

namespace HouseOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            GameManager gameManager = new GameManager();
            gameManager.ManageGame();
        }
    }
}
