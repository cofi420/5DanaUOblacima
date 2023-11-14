using Microsoft.AspNetCore.Mvc;

namespace _5DanaUOblacima.Service.PlayerService
{
    public interface IPlayerService
    {
        List<Player> GetAllPlayers();
        Player? GetSinglePlayer(string name);
    }
}
