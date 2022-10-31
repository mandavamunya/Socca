using System.Collections.Generic;
using System.Linq;
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
            var footballClubs = await _service.GetFootballClubs();
            if (footballClubs == null)
                return NoContent(); // '204': 'Not Found'
    
            return footballClubs.ToList();
        }

        [HttpGet("/{Id}")]
        public async Task<ActionResult<Domain.Entities.FootballClub>> Get([FromRoute] int id)
        {
            if (id < 1)
                return BadRequest(); // '400': 'Bad Request'

            var footballClub = await _service.Get(id);
            if (footballClub == null)
                return NotFound(); // '404': 'Not Found'

            return footballClub;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Domain.Entities.FootballClub footballClub)
        {
            if (footballClub.Id < 1)
                return BadRequest(); // '400': 'Bad Request'

            var dbFootballClub = await _service.Get(footballClub.Id);
            if (dbFootballClub == null)
                return NotFound(); // '404': 'Not Found'

            await _service.Update(footballClub);

            return NoContent();  // '204': 'No Content'
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            if (id < 1)
                return BadRequest(); // '400': 'Bad Request'

            var footballClub = await _service.Get(id);
            if (footballClub == null)
                return NotFound(); // '404': 'Not Found'

            await _service.Remove(footballClub);

            return NoContent(); // '204': 'No Content'
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Domain.Entities.FootballClub footballClub)
        {
            await _service.AddFootballClub(footballClub);
            // return Accepted(); // '202': 'Accepted'
            return Ok(); // '200' : 'Success'
        }

        [HttpPost("LinkToStadium")]
        public async Task<IActionResult> LinkToStadium([FromBody] AssignToStadium assignToStadium)
        {
            await _service.AssignToStadium(assignToStadium);
            return Ok();
        }
        
    }
}
