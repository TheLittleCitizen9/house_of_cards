using System;
using System.Collections.Generic;
using System.Text;

namespace HouseOfCards
{
    public class GameBoard
    {
        public Card[,] Board { get; }

        public GameBoard()
        {
            Board = new Card[5, 5];
        }

        public void PutCardOnBoard(Card card)
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j].Color == card.Color)
                    {
                        if(Board[i,j+1] == null)
                        {
                            Board[i, j + 1] = card;
                            break;
                        }
                        
                    }
                }
                
            }
        }
    }
}
