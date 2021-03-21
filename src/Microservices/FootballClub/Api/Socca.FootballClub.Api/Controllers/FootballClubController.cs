using Microsoft.AspNetCore.Mvc;

namespace Socca.FootballClub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballClubController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
