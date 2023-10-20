namespace NobelProject_API.Requests
{
    /// <summary>
    /// Represents a request to terminate a game.
    /// </summary>
    public class TerminateRequest
    {
        /// <summary>
        /// Gets or sets the game ID of the game to be terminated.
        /// </summary>
        public int GameId { get; set; }
    }
}
