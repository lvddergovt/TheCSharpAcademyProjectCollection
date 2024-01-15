namespace MathGame
{
    public class RandomGameMode : GameMode
    {
        /// <summary>
        /// Plays the random game mode.
        /// </summary>
        /// <param name="currentPlayer">The current player.</param>
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
}