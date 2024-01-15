using System;
using System.Collections.Generic;

namespace MathGame
{
    /// <summary>
    /// Represents a math game.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Gets or sets the current game mode.
        /// </summary>

        public GameMode CurrentGameMode { get; set; }

        /// <summary>
        /// Gets or sets the current player.
        /// </summary>
        public Player CurrentPlayer { get; set; }

        /// <summary>
        /// Starts the math game.
        /// </summary>
        public void StartGame()
        {
            Console.WriteLine("Please enter your name: ");
            string? userName = Console.ReadLine();
            DateTime now = DateTime.Now;
            CurrentPlayer = new Player(userName);
            bool keepPlaying = true;

            // while keepplaying is true, keep playing the game
            while (keepPlaying)
            {
                // ask the user to choose a game mode and give them the options
                Console.WriteLine($"Hi {userName}, today is {now} and it's time to play a math game. \nPlease choose a game mode: ");
                Console.WriteLine("A - addition");
                Console.WriteLine("S - subtraction");
                Console.WriteLine("M - multiplication");
                Console.WriteLine("D - division");
                Console.WriteLine("H - display game history");
                Console.WriteLine("R - random game mode");
                Console.WriteLine("Q - quit");

                // read the user's input
                string? gameMode = Console.ReadLine();

                // check if the user's input is not empty
                if (string.IsNullOrEmpty(gameMode))
                {
                    Console.WriteLine("Please enter a game mode!");
                }
                else
                {
                    if (gameMode.ToLower().Trim() == "a")
                    {
                        CurrentGameMode = new Addition();
                        CurrentGameMode.PlayGame(CurrentPlayer);
                    }
                    else if (gameMode.ToLower().Trim() == "s")
                    {
                        CurrentGameMode = new Subtraction();
                        CurrentGameMode.PlayGame(CurrentPlayer);
                    }
                    else if (gameMode.ToLower().Trim() == "m")
                    {
                        CurrentGameMode = new Multiplication();
                        CurrentGameMode.PlayGame(CurrentPlayer);
                    }
                    else if (gameMode.ToLower().Trim() == "d")
                    {
                        CurrentGameMode = new Division();
                        CurrentGameMode.PlayGame(CurrentPlayer);
                    }
                    else if (gameMode.ToLower().Trim() == "q")
                    {
                        Console.WriteLine("Goodbye!");
                        keepPlaying = false;
                    }
                    else if (gameMode.ToLower().Trim() == "h")
                    {
                        CurrentGameMode = new History();
                        CurrentGameMode.PlayGame(CurrentPlayer);
                    }
                    else if (gameMode.ToLower().Trim() == "r")
                    {
                        CurrentGameMode = new RandomGameMode();
                        CurrentGameMode.PlayGame(CurrentPlayer);
                    }
                    else
                    {
                        Console.WriteLine("Invalid game mode!");
                    }
                }
            }
        }
    }
}