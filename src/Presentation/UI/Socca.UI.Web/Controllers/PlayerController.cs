using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Socca.UI.Providers.DTOs;
using Socca.UI.Providers.Interfaces;

namespace Socca.UI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService service, IPlayerTransferService playerTransferService)
        {
            _playerService = service;
        }

        [HttpGet]
        public async Task<List<Player>> GetPlayers()
        {
            return await _playerService.GetPlayers();
        }

        [HttpPost]
        public async Task<string> AddPlayer(Player player)
        {
            return await _playerService.AddPlayer(player);
        }

        [HttpPost("Transfer")]
        public async Task<string> PlayerTransfer(PlayerTransfer playerTransfer)
        {
            return await _playerService.PlayerTransfer(playerTransfer);
        }
    }
}
