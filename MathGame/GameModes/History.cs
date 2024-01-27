namespace MathGame
{
    /// <summary>
    /// Represents the game mode for displaying the game history.
    /// </summary>
    public class History : GameMode
    {
        /// <summary>
        /// Plays the game in history mode and displays the game history for the current player.
        /// </summary>
        /// <param name="currentPlayer">The current player.</param>
        public override void PlayGame(Player currentPlayer)
        {
            Console.WriteLine("Game History:");
            foreach (string gameResult in currentPlayer.GameHistory)
            {
                Console.WriteLine(gameResult);
            }
        }
    }
}