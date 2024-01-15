namespace MathGame
{
    /// <summary>
    /// Represents the division game mode in the Math Game.
    /// </summary>
    public class Division : GameMode
    {
        /// <summary>
        /// Plays the division game mode.
        /// </summary>
        /// <param name="currentPlayer">The current player.</param>
        public override void PlayGame(Player currentPlayer)
        {
            base.PlayGame(currentPlayer, (num1, num2) => num1 / num2, "/");
        }
    }
    S
}