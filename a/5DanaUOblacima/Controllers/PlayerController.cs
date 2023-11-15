using _5DanaUOblacima.Model;
using _5DanaUOblacima.Service.PlayerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _5DanaUOblacima.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService) {
            this._playerService = playerService;
        }
        
        [HttpGet]
        public ActionResult<List<Player>> GetAllPlayers()
        {
            var players = _playerService.GetAllPlayers();
            return Ok(players);
        }
        [HttpGet("{name}")]
        public ActionResult<Player> GetSinglePlayer(string name)
        {
            var player = _playerService.GetSinglePlayer(name);
            if (player == null)
            {
                return NotFound("Player not found");
            }
            return Ok(player);
        }
    }
}
