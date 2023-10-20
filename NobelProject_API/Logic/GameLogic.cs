namespace NobelProject_API.Logic
{
    /// <summary>
    /// Represents a static class containing game logic for Rock, Paper, Scissors.
    /// </summary>
    public static class GameLogic
    {
        /// <summary>
        /// Generates a computer move (rock, paper, or scissors) based on a random value.
        /// </summary>
        /// <returns>A string representing the computer's move.</returns>
        public static string GenerateComputerMove()
        {

            Random random = new Random();
            int randomValue = random.Next(1, 4);


            if (randomValue == 1) return "rock";
            if (randomValue == 2) return "paper";
            return "scissors";
        }
        /// <summary>
        /// Determines the result of the game based on the user's move and the computer's move.
        /// </summary>
        /// <param name="userMove">The user's move (rock, paper, or scissors).</param>
        /// <param name="computerMove">The computer's move (rock, paper, or scissors).</param>
        /// <returns>A string indicating the game result (win, lose, or tie).</returns>
        public static string DetermineGameResult(string userMove, string computerMove)
        {

            if (userMove == computerMove) return "tie";
            if (
                (userMove == "rock" && computerMove == "scissors") ||
                (userMove == "paper" && computerMove == "rock") ||
                (userMove == "scissors" && computerMove == "paper")
            )
            {
                return "win";
            }
            return "lose";
        }
    }
}
