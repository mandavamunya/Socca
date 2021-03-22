using System.Collections.Generic;
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
        public ActionResult<IEnumerable<PlayerTransfer>> Get()
        {
            return Ok(_playerTransferService.GetPlayerTransfers());
        }
    }
}
