using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Socca.UI.Providers.DTOs;
using Socca.UI.Providers.Interfaces;

namespace Socca.UI.Web.Controllers
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
        public async Task<List<Stadium>> GetStadiums()
        {
            return await _service.GetStadiums();
        }

        [HttpPost]
        public async Task<string> AddStadium(Stadium stadium)
        {
            return await _service.AddStadium(stadium);
        }
    }
}
