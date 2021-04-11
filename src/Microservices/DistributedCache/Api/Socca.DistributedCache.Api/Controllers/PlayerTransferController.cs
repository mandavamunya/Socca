using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Socca.DistributedCache.Domain.Interfaces;

namespace Socca.DistributedCache.Api.Controllers
{
    public class PlayerTransferController : ControllerBase
    {
        private readonly IPlayerTransferService _service;

        public PlayerTransferController(IPlayerTransferService service)
        {
            _service = service;
        }

        [HttpGet("/{key}")]
        public async Task<IActionResult> Get([FromRoute] int key)
        {
            return Ok(await _service.Get(key));
        }
    }
}
