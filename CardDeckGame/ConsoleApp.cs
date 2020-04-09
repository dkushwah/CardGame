using CardDeckGame.Contract;
using CardDeckGame.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CardDeckGame.Impl;

namespace CardDeckGame
{
    public class ConsoleApp
    {
        private readonly IDeck<Suits,Face> _deck;
        private readonly IEnumerable<IPlayer> _players;

        public ConsoleApp(IDeck<Suits, Face> deck,IEnumerable<IPlayer> players)
        {
            this._deck = deck;
            this._players = players;
        }

        public Queue<string> playerNames = new Queue<string>();
        private int CardsForEachPlayer=> _deck.Cards.Count / _players.Count();
        public void Run()
        {
            //Generate Main Deck 
            _deck.GenerateDeck();
            _deck.ShuffleCard();
            Console.Write("Enter Player Name:");
            var firstPlayerName= Console.ReadLine();
            _players.FirstOrDefault().Name = firstPlayerName;
            if (string.IsNullOrWhiteSpace(firstPlayerName))
            {
                _players.FirstOrDefault().Name = "Me";
            }
            
            StartGame(CardsForEachPlayer);
            while (true)
            {

                int totalMoves = 0;
                bool isRestart = false;
                while (_players.All(t => !t.Deck.IsDeckEmpty()))
                {
                    
                    ShuffleResetContinueOrExit(out isRestart);
                    if (isRestart)
                    {
                        totalMoves = 0;
                    }
                    var playerByFaceValues = new Dictionary<LsCard, IPlayer>();
                    foreach (var player in _players)
                    {
                        var card = player.Deck.DrawCard() as LsCard;
                        Console.WriteLine();
                        Console.WriteLine($"{player.Name} has thrown ");
                        card.PrintCard();
                        if (!playerByFaceValues.ContainsKey(card))
                        {
                            playerByFaceValues.Add(card, player);
                        }
                    }

                    if (playerByFaceValues.Count == 1)
                    {
                        Console.WriteLine("---------------------------");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"It's Draw!");
                        Console.ResetColor();
                        Console.WriteLine("---------------------------");
                    }
                    else
                    {
                        var winnerPlayer = playerByFaceValues.OrderByDescending(t => t.Key.GetFaceValue()).FirstOrDefault();
                        Console.WriteLine("---------------------------");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{winnerPlayer.Value.Name} has won!");
                        winnerPlayer.Value.Deck.AddCardsInDeck(playerByFaceValues.Keys.ToArray());
                        Console.ResetColor();
                        Console.WriteLine("---------------------------");
                    }
                    totalMoves++;
                    Console.WriteLine($"No of moves till now:{totalMoves}");
                }
                var winner = _players.FirstOrDefault(t => !t.Deck.IsDeckEmpty());
                Console.WriteLine("--------------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{winner?.Name} has won the Game with {totalMoves} moves.");
                Console.ResetColor();
                Console.WriteLine("--------------------------------------");
                ConsoleKeyInfo input;
                while(true)
                {
                    Console.WriteLine("Would you like to play again?\nIf yes, type 'y'. If not, type 'n'.\n");
                    input = Console.ReadKey();
                    if (input.Key == ConsoleKey.Y)
                    {
                        break;
                    }
                    if (input.Key == ConsoleKey.N)
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }

        private void StartGame(int cardsForEachPlayer, bool isRestart = false)
        {
            int skip = 0;
            int counter = 1;
            foreach (var player in _players)
            {
                player.Name ??= $"Bot {counter++}";
                player.Deck.Cards = this._deck.Cards.Skip(skip).Take(cardsForEachPlayer).ToList();
                skip += cardsForEachPlayer;
                Console.WriteLine($"\nPlayer {player.Name} has {player.Deck.Cards.Count} Cards in hand");
            }
            if (isRestart)
            {
                Console.WriteLine("***********************");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Game Restarted");
                Console.ResetColor();
                Console.WriteLine("***********************");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShuffleResetContinueOrExit(out bool isRestart)
        {
            isRestart = false;
            ConsoleKeyInfo consoleKey;
            do
            {
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Hit one of the listed Key");
                Console.WriteLine("---------------------------------------------");
                Console.Write("Enter to play,S to shuffle,R to restart the Game,Esc to Exit the Game\n");
                Console.Write("Hit your choise:");
                consoleKey = Console.ReadKey();
                switch (consoleKey.Key)
                {
                    case ConsoleKey.S:
                        _players.FirstOrDefault().Deck.ShuffleCard();
                        Console.WriteLine($"\nCard shuffled successfully for {_players.FirstOrDefault().Name}");
                        break;
                    case ConsoleKey.R:
                        if (!isRestart)
                        {
                            StartGame(CardsForEachPlayer, true);
                            isRestart = true;
                        }
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            } while (consoleKey.Key != ConsoleKey.Enter);
            
        }

    }
}
