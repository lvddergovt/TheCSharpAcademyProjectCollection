namespace MathGame
{
    /// <summary>
    /// Represents the subtraction game mode.
    /// </summary>
    public class Subtraction : GameMode
    {
        /// <summary>
        /// Plays the subtraction game mode.
        /// </summary>
        /// <param name="currentPlayer">The current player.</param>
        public override void PlayGame(Player currentPlayer)
        {
            base.PlayGame(currentPlayer, (num1, num2) => num1 - num2, "-");
        }
    }
}