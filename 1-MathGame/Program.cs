using System;
using System.Collections.Generic; // Add missing using statement
using MathGame;

/// <summary>
/// Represents the entry point of the Math Game program.
/// </summary>
public class Program
{
    /// <summary>
    /// The main method that starts the Math Game.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    static void Main(string[] args)
    {
        Game game = new Game();
        game.StartGame();
    }
}
