namespace MathGame
{
    /// <summary>
    /// Represents the addition game mode in the Math Game.
    /// </summary>
    public class Addition : GameMode
    {
        /// <summary>
        /// Plays the addition game mode.
        /// </summary>
        /// <param name="currentPlayer">The current player.</param>
        public override void PlayGame(Player currentPlayer)
        {
            base.PlayGame(currentPlayer, (num1, num2) => num1 + num2, "+");
        }
    }
}