using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Socca.UI.Providers.DTOs;
using Socca.UI.Providers.Interfaces;

namespace Socca.UI.Providers.Services
{
    public class FootballClubStadiumService: IFootballClubStadiumService
    {

        private readonly HttpClient _httpClient;

        public FootballClubStadiumService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FootballClubStadium>> GetFootballClubs()
        {
            using (var response = await _httpClient.GetAsync("api/FootballClubStadium/"))
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<FootballClubStadium>>(data);
            }
        }

    }
}
