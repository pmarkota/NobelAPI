using Microsoft.AspNetCore.Mvc;
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


        [HttpPost("start")]
        public ActionResult<Game> StartGame([FromBody] long playerId)
        {
            Game game = new Game();
            game.PlayerId = playerId;

            _db.Games.Add(game);
            _db.SaveChanges();
            var gameId = game.Id;
            return Ok(new { gameId, playerId, message = "Game started." });
        }

        /// <summary>
        /// Play a move in an ongoing game.
        /// </summary>
        [HttpPost("play")]
        public ActionResult<Game> PlayGame([FromBody] MoveRequest moveRequest)
        {
            long gameId = moveRequest.GameId;
            Game game = _db.Games.Find(gameId);
            if (game == null)
            {
                return NotFound(new { message = "Game not found." });
            }
            string userMove = moveRequest.UserMove;
            string computerMove = GameLogic.GenerateComputerMove();
            string result = GameLogic.DetermineGameResult(userMove, computerMove);

            GameMove gameMove = new GameMove();
            gameMove.GameId = gameId;
            gameMove.PlayerId = moveRequest.PlayerId;
            gameMove.UserMove = userMove;
            gameMove.ComputerMove = computerMove;
            gameMove.Result = result;

            _db.GameMoves.Add(gameMove);
            //Update player statistics
            var playerStatistic = _db.PlayerStatistics.Find(game.PlayerId);
            if (playerStatistic == null)
            {
                playerStatistic = new PlayerStatistic();
                playerStatistic.PlayerId = (long)game.PlayerId;
                playerStatistic.Wins = 0;
                playerStatistic.Losses = 0;
                playerStatistic.Ties = 0;
                playerStatistic.TotalGamesPlayed = 0;
                _db.PlayerStatistics.Add(playerStatistic);
                _db.SaveChanges();
            }
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

            return Ok(new { gameId, userMove, computerMove, result });
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

    }
}
