using System;
using System.Collections.Generic; // Add missing using statement

/// <summary>
/// This program allows the user to play a math game by choosing a game mode (addition, subtraction, multiplication, or division) and answering math questions.
/// </summary>

public class Program
{
  static void Main(string[] args)
  {

    Game game = new Game();
    game.StartGame();
  }
}

public class Player
{
  public string Name { get; set; }
  public List<string> GameHistory { get; set; }

  public Player(string? name)
  {
    Name = name;
    GameHistory = new List<string>();
  }

  public void AddGameToHistory(string game)
  {
    GameHistory.Add(game);
  }
}

public abstract class GameMode
{
  public virtual void PlayGame(Player currentPlayer)
  {
    // Default implementation (does nothing)
  }

  public virtual void PlayGame(Player currentPlayer, Func<int, int, int> operation, string operationSymbol)
  {
    Random random = new Random();

    // create 2 random numbers
    int num1 = random.Next(1, 11);
    int num2 = random.Next(1, 11);

    // ask the user to perform the operation on the 2 numbers
    Console.WriteLine($"What is {num1} {operationSymbol} {num2}?");
    // create a NumberFormatInfo object that allows both dot and comma as decimal separators
    var format = new System.Globalization.NumberFormatInfo();
    format.NumberDecimalSeparator = ".";
    format.NumberGroupSeparator = ",";
    double answer = Convert.ToDouble(Console.ReadLine(), format);

    // check if the user's answer is correct
    if (Math.Abs(answer - operation(num1, num2)) < 0.001)
    {
      Console.WriteLine("Correct!");
      currentPlayer.GameHistory.Add($"{operationSymbol} game: {num1} {operationSymbol} {num2} = {answer} (Correct)");
    }
    else
    {
      Console.WriteLine("Incorrect!");
      currentPlayer.GameHistory.Add($"{operationSymbol} game: {num1} {operationSymbol} {num2} = {answer} (Incorrect)");
    }
  }
}

public class Addition : GameMode
{
  public override void PlayGame(Player currentPlayer)
  {
    base.PlayGame(currentPlayer, (num1, num2) => num1 + num2, "+");
  }
}

public class Subtraction : GameMode
{
  public override void PlayGame(Player currentPlayer)
  {
    base.PlayGame(currentPlayer, (num1, num2) => num1 - num2, "-");
  }
}

public class Multiplication : GameMode
{
  public override void PlayGame(Player currentPlayer)
  {
    base.PlayGame(currentPlayer, (num1, num2) => num1 * num2, "*");
  }
}

public class Division : GameMode
{
  public override void PlayGame(Player currentPlayer)
  {
    base.PlayGame(currentPlayer, (num1, num2) => num1 / num2, "/");
  }
}
// 'random' game mode function where the user gets 10 questions from random game modes
public class RandomGameMode : GameMode
{
  public override void PlayGame(Player currentPlayer)
  {
    Console.WriteLine("Random Game Mode:");
    for (int i = 0; i < 10; i++)
    {
      Random random = new Random();
      int randomGameMode = random.Next(1, 5);
      if (randomGameMode == 1)
      {
        Addition addition = new Addition();
        addition.PlayGame(currentPlayer);
      }
      else if (randomGameMode == 2)
      {
        Subtraction subtraction = new Subtraction();
        subtraction.PlayGame(currentPlayer);
      }
      else if (randomGameMode == 3)
      {
        Multiplication multiplication = new Multiplication();
        multiplication.PlayGame(currentPlayer);
      }
      else if (randomGameMode == 4)
      {
        Division division = new Division();
        division.PlayGame(currentPlayer);
      }
    }
  }
}

public class History : GameMode
{
  public override void PlayGame(Player currentPlayer)
  {
    Console.WriteLine("Game History:");
    foreach (string gameResult in currentPlayer.GameHistory)
    {
      Console.WriteLine(gameResult);
    }
  }
}

public class Game
{
  public GameMode CurrentGameMode { get; set; }
  public Player CurrentPlayer { get; set; }



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

