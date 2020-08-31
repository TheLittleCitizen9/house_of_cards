using System;
using System.Collections.Generic;
using System.Text;

namespace HouseOfCards
{
    public class GameBoard
    {
        public Dictionary<string, List<Card>> Board{ get; }

        public GameBoard()
        {
            Board = new Dictionary<string, List<Card>>();
            ResetBoard();
        }
        private void ResetBoard()
        {
            foreach (string color in Enum.GetNames(typeof(CardColors)))
            {
                Board.Add(color, new List<Card>());
            }
        }
        public void PutCardOnBoard(Card card)
        {
            Board[card.Color.ToString()].Add(card);
        }
    }
}
