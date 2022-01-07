using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Socca.UI.Providers.DTOs;
using Socca.UI.Providers.Interfaces;

namespace Socca.UI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballClubStadiumController: ControllerBase
    {

        private readonly IFootballClubStadiumService _service;

        public FootballClubStadiumController(IFootballClubStadiumService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<FootballClubStadium>> GetFootballClubs()
        {
            return await _service.GetFootballClubs();
        }
    }
}
