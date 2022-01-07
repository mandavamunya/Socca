using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Socca.UI.Providers.DTOs;
using Socca.UI.Providers.Interfaces;

namespace Socca.UI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerTransferController : ControllerBase
    {

        private readonly IPlayerTransferService _playerTransferService;

        public PlayerTransferController(IPlayerTransferService playerTransferService)
        {
            _playerTransferService = playerTransferService;
        }

        [HttpGet("{key}")]
        public async Task<PlayerTransfer> GetPlayerTransfer(int key)
        {
            return await _playerTransferService.GetPlayerTransfer(key);
        }

        [HttpGet]
        public async Task<List<PlayerTransfer>> GetPlayerTransfers()
        {
            return await _playerTransferService.GetPlayerTransfers();
        }
    }
}
