using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Socca.DistributedCache.Domain.Interfaces;

namespace Socca.DistributedCache.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballClubToStadiumController : ControllerBase
    {
        private readonly IFootballClubToStadiumService _service;

        public FootballClubToStadiumController(IFootballClubToStadiumService service)
        {
            _service = service;
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> Get([FromRoute] int key)
        {
            return Ok(await _service.Get(key));
        }
    }
}
