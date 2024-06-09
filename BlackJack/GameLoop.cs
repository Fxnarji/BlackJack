using System;
using System.Diagnostics;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace BlackJack
{
    public enum GameEndState
    {
        PlayerLost,
        PlayerDraws,
    }
    public class GameLoop
    {
        private Player[] _players;
        private int _decks;
        private Generator _g = new Generator(); 
        bool IsGameRunning = true;


        public GameLoop()
        {

        }


        void EndGame(GameEndState GES, Player player)
        {
            IsGameRunning = false;
            switch(GES)
            {
                case GameEndState.PlayerLost:
                    Console.WriteLine($"Player {player} lost the game by getting more than 21 points!");
                    break;
                case GameEndState.PlayerDraws:
                    Console.WriteLine($"Player {player} ended the game at {player.CardCount} points");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(GES), GES, null);
            }

            Console.ReadKey();
        }
        public void Play()
        {
            GetPlayerInput();
            
            //fill players
            for (int i = 0; i < _players.Length; i++)
            {
                _players[i] = new Player(i);
                _players[i].LostGame += EndGame;
            }

            MainLoop();
        }

        private void GetPlayerInput()
        {
            Console.WriteLine("How many Players do you want?");
            string userInput = Console.ReadLine();

            //check if string is clear
            if (Int32.TryParse(userInput, out int players))
            {
                _players = new Player[players+1]; //+1 accounts for dealer here
            }
            else
            {
                Console.WriteLine($"{userInput} is not a valid number, try again");
                Play();
            }

            Console.WriteLine("How many Decks do you want?");
            userInput = Console.ReadLine();

            //check if string is clear
            if (Int32.TryParse(userInput, out int deckAmount))
            {
                _g.Init(deckAmount);
            }
            else
            {
                Console.WriteLine($"{userInput} is not a valid number, try again");
                Play();
            }
        }

        void MainLoop()
        {


            while (IsGameRunning)
            {
                foreach (Player p in _players)
                {
                    Console.Clear();
                    Console.WriteLine($"player {p.PlayerNumber}'s turn. Press [RETURN] to draw a Card!\nType n to end the game");
                    foreach(Player p2 in _players)
                    {
                        
                        Console.WriteLine($"{p2.PlayerNumber} counts: {p2.CardCount}");
                    }

                    string input =  Console.ReadLine();
                    if (input.Equals("n"))
                    {
                        EndGame(GameEndState.PlayerDraws, p);
                    }
                    p.Draw(_g);

                }
            }
        }
    }
}