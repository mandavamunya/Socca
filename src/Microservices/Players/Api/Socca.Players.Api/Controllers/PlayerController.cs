using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Socca.Players.Domain.Models;
using Socca.Players.Domain.Entities;
using Socca.Players.Domain.Interfaces;
using System.Linq;

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
            var players = await _playerService.GetPlayers();
            if (players == null)
                return NoContent(); // '204': 'Not Found'

            return players.ToList();
        }


        [HttpGet("/{Id}")]
        public async Task<ActionResult<Domain.Entities.Player>> Get([FromRoute] int id)
        {
            if (id < 1)
                return BadRequest(); // '400': 'Bad Request'

            var player = await _playerService.Get(id);
            if (player == null)
                return NotFound(); // '404': 'Not Found'

            return player;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Domain.Entities.Player player)
        {
            if (player.Id < 1)
                return BadRequest(); // '400': 'Bad Request'

            var dbPlayer = await _playerService.Get(player.Id);
            if (dbPlayer == null)
                return NotFound(); // '404': 'Not Found'

            await _playerService.Update(player);

            return NoContent();  // '204': 'No Content'
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            if (id < 1)
                return BadRequest(); // '400': 'Bad Request'

            var player = await _playerService.Get(id);
            if (player == null)
                return NotFound(); // '404': 'Not Found'

            await _playerService.Remove(player);

            return NoContent(); // '204': 'No Content'
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
