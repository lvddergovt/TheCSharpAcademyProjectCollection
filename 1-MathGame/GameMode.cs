using System;
using System.Collections.Generic;

namespace MathGame
{
    public abstract class GameMode
    {
        /// <summary>
        /// Plays the game for the specified player.
        /// </summary>
        /// <param name="currentPlayer">The player who is playing the game.</param>
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
}