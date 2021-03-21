using Microsoft.AspNetCore.Mvc;

namespace Socca.PlayerTransfers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerTransferController: ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
