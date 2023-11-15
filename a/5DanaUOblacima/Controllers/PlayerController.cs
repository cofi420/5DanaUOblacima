using _5DanaUOblacima.Model;
using _5DanaUOblacima.Service.PlayerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _5DanaUOblacima.Controllers
{
    [Route("/stats/player")]
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
        [HttpGet("{playerFullName}")]
        public ActionResult<Player> GetSinglePlayer(string playerFullName)
        {
            var player = _playerService.GetSinglePlayer(playerFullName);
            if (player == null)
            {
                return NotFound("Player not found");
            }
            return Ok(player);
        }
    }
}
