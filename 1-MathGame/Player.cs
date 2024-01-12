using System;
using System.Collections.Generic;

namespace MathGame
{
  /// <summary>
  /// Represents a player in the game.
  /// </summary>
  public class Player
  {
    /// <summary>
    /// Gets or sets the name of the player.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the game history of the player.
    /// </summary>
    public List<string> GameHistory { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Player"/> class.
    /// </summary>
    /// <param name="name">The name of the player.</param>
    public Player(string? name)
    {
      Name = name;
      GameHistory = new List<string>();
    }

    /// <summary>
    /// Adds a game to the player's game history.
    /// </summary>
    /// <param name="game">The game to be added.</param>
    public void AddGameToHistory(string game)
    {
      GameHistory.Add(game);
    }
  }
}