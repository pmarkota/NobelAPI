using Microsoft.AspNetCore.Mvc;
using NobelProject_API.Models;
using NobelProject_API.Requests;


namespace NobelProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PostgresContext _db;
        public PlayerController(PostgresContext db)
        {
            _db = db;
        }

        [HttpPost("register")]
        public ActionResult<Player> Register([FromBody] PlayerRegisterRequest request)
        {
            var player = new Player
            {
                Username = request.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            _db.Players.Add(player);
            _db.SaveChanges();

            return Ok(new { player.Id, player.Username });
        }

        [HttpPost("login")]
        public ActionResult<Player> Login([FromBody] PlayerLoginRequest request)
        {
            var player = _db.Players.SingleOrDefault(p => p.Username == request.Username);

            if (player == null)
            {
                return NotFound();
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, player.PasswordHash))
            {
                return Unauthorized();
            }

            return Ok(new { player.Id, player.Username });
        }

    }
}
