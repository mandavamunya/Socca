using Microsoft.AspNetCore.Mvc;

namespace Socca.FootballClubStadium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballClubStadiumController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
