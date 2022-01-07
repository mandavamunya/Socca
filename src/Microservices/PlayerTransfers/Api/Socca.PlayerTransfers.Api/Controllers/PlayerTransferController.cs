using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Socca.PlayerTransfers.Application.Interfaces;
using Socca.PlayerTransfers.Domain.Entities;

namespace Socca.PlayerTransfers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerTransferController: ControllerBase
    {
        private readonly IPlayerTransferService _playerTransferService;

        public PlayerTransferController(IPlayerTransferService playerTransferService)
        {
            _playerTransferService = playerTransferService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerTransfer>>> Get()
        {
            return Ok(await _playerTransferService.GetPlayerTransfers());
        }

        //[HttpGet("{key}")]
        //public async Task<ActionResult<IEnumerable<PlayerTransfer>>> Get([FromRoute]int key)
        // {
        //    return Ok(await _playerTransferService.GetPlayerTransfers(key));
        // }
    }
}
