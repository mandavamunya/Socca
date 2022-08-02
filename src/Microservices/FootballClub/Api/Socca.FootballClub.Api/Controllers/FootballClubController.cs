using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Socca.FootballClub.Domain.Interfaces;
using Socca.FootballClub.Domain.Models;

namespace Socca.FootballClub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballClubController : ControllerBase
    {
        private readonly IFootballClubService _service;
        public FootballClubController(IFootballClubService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Entities.FootballClub>>> Get()
        {
            return Ok(await _service.GetFootballClubs());
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Domain.Entities.FootballClub footballClub)
        {
            await _service.AddFootballClub(footballClub);
            return Ok();
        }

        [HttpPost("LinkToStadium")]
        public async Task<IActionResult> LinkToStadium([FromBody] AssignToStadium assignToStadium)
        {
            await _service.AssignToStadium(assignToStadium);
            return Ok();
        }
        
    }
}
