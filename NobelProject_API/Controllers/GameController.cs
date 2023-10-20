using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NobelProject_API.Logic;
using NobelProject_API.Models;
using NobelProject_API.Requests;

namespace NobelProject_API.Controllers
{
    //Rock-paper-scissors game controller
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly PostgresContext _db;
        public GameController(PostgresContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Start a new game.
        /// </summary>
        [HttpPost("start")]
        public ActionResult<Game> StartGame()
        {
            Game game = new Game();
            _db.Games.Add(game);
            _db.SaveChanges();
            var gameId = game.Id;
            return Ok(new { gameId, message = "Game started." });
        }

        /// <summary>
        /// Play a move in an ongoing game.
        /// </summary>
        [HttpPost("play")]
        public ActionResult<Game> PlayGame([FromBody] MoveRequest moveRequest)
        {
            string userMove = moveRequest.UserMove;
            string compterMove = GameLogic.GenerateComputerMove();
            string result = GameLogic.DetermineGameResult(userMove, compterMove);
            GameMove gameMove = new GameMove
            {
                GameId = moveRequest.GameId,
                UserMove = userMove,
                ComputerMove = compterMove,
                Result = result
            };
            _db.GameMoves.Add(gameMove);
            PlayerStatistic playerStatistic = _db.PlayerStatistics.Find((long)1);
            if (result == "win")
            {
                playerStatistic.Wins++;
            }
            else if (result == "lose")
            {
                playerStatistic.Losses++;
            }
            else
            {
                playerStatistic.Ties++;
            }
            playerStatistic.TotalGamesPlayed++;
            _db.PlayerStatistics.Update(playerStatistic);

            _db.SaveChanges();
            return Ok(new { compterMove, result });
        }

        /// <summary>
        /// Terminate an ongoing game.
        /// </summary>
        [HttpPost("terminate")]
        public IActionResult TerminateGame([FromBody] TerminateRequest terminateRequest)
        {
            long gameId = terminateRequest.GameId;
            Game game = _db.Games.Find(gameId);
            if (game == null)
            {
                return NotFound(new { message = "Game not found." });
            }
            _db.Games.Remove(game);
            _db.SaveChanges();

            return Ok(new { message = "Game terminated." });
        }
        /// <summary>
        /// Get player statistics.
        /// </summary>
        [HttpGet("statistics")]
        public ActionResult<PlayerStatistic> GetPlayerStatistic()
        {
            PlayerStatistic playerStatistic = _db.PlayerStatistics.Find((long)1);
            if (playerStatistic == null)
            {
                return NotFound(new { message = "No records yet" });
            }
            return Ok(playerStatistic);
        }
        /// <summary>
        /// Delete all games and statistics.
        /// </summary>
        [HttpDelete("delete")]
        public IActionResult DeleteAll()
        {
            _db.Database.ExecuteSqlRaw("DELETE FROM \"GameMoves\"");
            _db.Database.ExecuteSqlRaw("DELETE FROM \"Games\"");
            var playerStatistic = _db.PlayerStatistics.Find((long)1);
            playerStatistic.Wins = 0;
            playerStatistic.Losses = 0;
            playerStatistic.Ties = 0;
            playerStatistic.TotalGamesPlayed = 0;
            _db.PlayerStatistics.Update(playerStatistic);
            _db.SaveChanges();

            return Ok(new { message = "All games and statistics deleted." });
        }
    }
}
