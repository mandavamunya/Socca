using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Socca.UI.Providers.DTOs;
using Socca.UI.Providers.Interfaces;

namespace Socca.UI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballClubController: ControllerBase
    {
        private readonly IFootballClubService _service;

        public FootballClubController(IFootballClubService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<FootballClub>> GetFootballClubs()
        {
            return await _service.GetFootballClubs();
        }

        [HttpPost]
        public async Task<string> AddFootballClubs(FootballClub footballClub)
        {
            return await _service.AddFootballClubs(footballClub);
        }

        [HttpPost("LinkToStadium")]
        public async Task<string> LinkToStadium(AssignToStadium assignToStadium)
        {
            return await _service.LinkToStadium(assignToStadium);
        }
    }
}
