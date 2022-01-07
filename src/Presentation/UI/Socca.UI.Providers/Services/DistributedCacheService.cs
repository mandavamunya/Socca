using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Socca.UI.Providers.DTOs;
using Socca.UI.Providers.Interfaces;

namespace Socca.UI.Providers.Services
{
    public class DistributedCacheService: IDistributedCacheService
    {

        private readonly HttpClient _httpClient;

        public DistributedCacheService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PlayerTransfer> GetPlayerTransfer(int key)
        {
            using (var response = await _httpClient.GetAsync($"api/PlayerTransfer/{key}"))
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PlayerTransfer>(data);
            }
        }

        public async Task<FootballClubStadium> GetFootballClubStadium(int key)
        {
            using (var response = await _httpClient.GetAsync($"api/FootballClubStadium/{key}"))
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<FootballClubStadium>(data);
            }
        }

    }
}
