using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Socca.FootballClubStadium.Application.Interfaces;

namespace Socca.FootballClubStadium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballClubStadiumController : ControllerBase
    {
        private readonly IFootballClubStadiumService _service;
        public FootballClubStadiumController(IFootballClubStadiumService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Entities.FootballClubStadium>>> Get()
        {
            return Ok(await _service.Get());
        }

    }
}
