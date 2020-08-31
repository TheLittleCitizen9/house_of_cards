﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HouseOfCards
{
    public class GameManager
    {
        private int _strikeCounter = 4;
        private int _cluesCounter = 5;
        public GameBoard GameBoard;
        public List<Player> Players;
        public CardsDeck CardsDeck;

        public GameManager()
        {
            GameBoard = new GameBoard();
            Players = new List<Player>();
            CardsDeck = new CardsDeck();
        }

        public void ManageGame()
        {
            int indexOfPlayer = 0;
            //CardsDeck.GenerateDeck();
            Console.WriteLine("Welcom to House Of Cards");
            Console.WriteLine("Enter players");
            RegisterPlayers();
            CardsDeck.ShuffleDeck();
            Deal();
            Player currentPlayer = null;
            while(CheckDeckStatus())
            {
                if(indexOfPlayer > 4)
                {
                    indexOfPlayer = indexOfPlayer - 4;
                }
                currentPlayer = Players[indexOfPlayer];
                PrintMenu();
                int option = int.Parse(Console.ReadLine());
                if(option == 1)
                {
                    ShowOtherPlayersCards(currentPlayer);
                }
                else if(option == 2)
                {
                    Console.WriteLine("Enter card number to throw - between 1-5");
                    int index = int.Parse(Console.ReadLine());
                    Card card = ThrowPlayersCard(currentPlayer, index);
                    if(!CheckIfCardIsValid(card))
                    {
                        _strikeCounter--;
                    }
                    else
                    {
                        GivePlayerNewCard(currentPlayer);
                    }
                }
                else if (option == 3)
                {
                    _cluesCounter--;
                    currentPlayer.ShowRandomCard();
                }
                else if (option == 4)
                {
                    if(IncreaseCluesCounter())
                    {
                        Random rnd = new Random();
                        Card card = ThrowPlayersCard(currentPlayer, rnd.Next(5));
                        GivePlayerNewCard(currentPlayer);
                    }
                }
                if(_strikeCounter == 0)
                {
                    Console.WriteLine("Your Group Lost :(");
                    break;
                }
            }
            if(_strikeCounter > 0)
            {
                int score = CalculateScore();
                if(score == 25)
                {
                    Console.WriteLine("You won! Your score is 25!!");
                }
                else
                {
                    Console.WriteLine($"Game Over. Your score is {score}");
                }
            }
        }

        public void RegisterPlayers()
        {
            for (int i = 0; i < 4; i++)
            {
                string name = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(name) || !string.IsNullOrEmpty(name))
                {
                    if(Players.Count < 4)
                    {
                        Players.Add(new Player(name));
                    }
                    else
                    {
                        Console.WriteLine("Only 4 players can play");
                    }
                }
            }
        }

        public Card ThrowPlayersCard(Player player, int index)
        {
            Card card = player.Cards[index - 1];
            player.Cards = player.Cards.Where((card, indx) => indx != index - 1).ToArray();
            return card;
        }

        public bool CheckIfCardIsValid(Card card)
        {
            for (int i = 0; i < GameBoard.Board.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.Board.GetLength(1); j++)
                {
                    if(GameBoard.Board[i,j].Color == card.Color)
                    {
                        if(GameBoard.Board[i,j].Number +1 == card.Number)
                        {
                            GameBoard.PutCardOnBoard(card);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if(GameBoard.Board[i,j] == null)
                    {
                        GameBoard.PutCardOnBoard(card);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IncreaseCluesCounter()
        {
            if(_cluesCounter < 5)
            {
                _cluesCounter++;
                return true;
            }
            Console.WriteLine("You already have 5 clues");
            return false;
        }

        public bool CheckDeckStatus()
        {
            if(CardsDeck.Deck.Length > 0)
            {
                return true;
            }
            return false;
        }

        public void GivePlayerNewCard(Player player)
        {
            if(player.Cards[player.Cards.Length-1] == null)
            {
                player.Cards[player.Cards.Length - 1] = CardsDeck.GetCardsFromDeck(1)[0];
            }
            else
            {
                Console.WriteLine($"{player.Name} already has 5 cards");
            }
        }

        public int CalculateScore()
        {
            int score = 0;
            for (int i = 0; i < GameBoard.Board.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.Board.GetLength(1); j++)
                {
                    if(GameBoard.Board[i,j] != null)
                    {
                        score++;
                    }
                }
            }
            return score;
        }

        public bool DisqualifyGroup()
        {
            if(_strikeCounter > 0)
            {
                return true;
            }
            return false;
        }

        public bool CheckWinningStatus()
        {
            int fivesCounter = 0;
            int j = GameBoard.Board.GetLength(1) - 1;
            for (int i = 0; i < GameBoard.Board.GetLength(0); i++)
            {
                if(GameBoard.Board[i, j] != null && GameBoard.Board[i, j].Number == 5)
                {
                    fivesCounter++;
                }
            }
            if(fivesCounter == 5)
            {
                return true;
            }
            return false;
        }

        private void Deal()
        {
            foreach (var player in Players)
            {
                player.Cards = CardsDeck.GetCardsFromDeck(5);
            }
        }

        private void ShowOtherPlayersCards(Player player)
        {
            foreach (var p in Players)
            {
                if(p != player)
                {
                    p.ShowCards();
                }
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("1 - Show Other Players Cards");
            Console.WriteLine("2 - Play Card");
            Console.WriteLine("3 - Get Clue");
            Console.WriteLine("4 - Throw Card");
        }
    }
}
