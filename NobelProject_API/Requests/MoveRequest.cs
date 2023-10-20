using Newtonsoft.Json;

namespace NobelProject_API.Requests
{
    /// <summary>
    /// Represents a request to make a move in a game.
    /// </summary>
    public class MoveRequest
    {
        /// <summary>
        /// Gets or sets the game ID for the ongoing game.
        /// </summary>
        [JsonProperty("gameId")]
        public int GameId { get; set; }

        /// <summary>
        /// PlayerID
        /// </summary>
        [JsonProperty("playerId")]
        public long PlayerId { get; set; }

        /// <summary>
        /// Gets or sets the user's move (e.g., "rock," "paper," or "scissors").
        /// </summary>
        [JsonProperty("userMove")]
        public string UserMove { get; set; }
    }
}
