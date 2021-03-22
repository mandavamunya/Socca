using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Socca.Stadium.Application.Interfaces;

namespace Socca.Stadium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly IStadiumService _service;
        public StadiumController(IStadiumService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Domain.Entities.Stadium>> Get()
        {
            return Ok(_service.GetStadiums());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Domain.Entities.Stadium stadium)
        {
            await _service.AddStadium(stadium);
            return Ok();
        }
    }
}
