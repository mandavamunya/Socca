using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Socca.Players.Application.Interfaces;
using Socca.Players.Application.Models;
using Socca.Players.Domain.Entities;

namespace Socca.Players.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> Get()
        {
            return Ok(await _playerService.GetPlayers());
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Player player)
        {
            await _playerService.AddPlayer(player);
            return Ok();
        }

        [HttpPost("Transfer")]
        public async Task<IActionResult> PlayerTransfer([FromBody] PlayerTransfer playerTransfer)
        {
            await _playerService.Transfer(playerTransfer);
            return Ok();
        }
    }
}
