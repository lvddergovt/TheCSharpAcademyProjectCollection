namespace MathGame
{
    /// <summary>
    /// Represents the multiplication game mode.
    /// </summary>
    public class Multiplication : GameMode
    {
        /// <summary>
        /// Plays the multiplication game.
        /// </summary>
        /// <param name="currentPlayer">The current player.</param>
        public override void PlayGame(Player currentPlayer)
        {
            base.PlayGame(currentPlayer, (num1, num2) => num1 * num2, "*");
        }
    }
}