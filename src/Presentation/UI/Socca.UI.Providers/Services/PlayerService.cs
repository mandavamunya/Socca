using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Socca.UI.Providers.DTOs;
using Socca.UI.Providers.Interfaces;

namespace Socca.UI.Providers.Services
{
    public class PlayerService: IPlayerService
    {

        private readonly HttpClient _httpClient;

        public PlayerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<Player>> GetPlayers()
        {
            using (var response = await _httpClient.GetAsync("api/Player"))
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Player>>(data);
            }
        }

        public async Task<string> AddPlayer(Player player)
        {
            var json = JsonConvert.SerializeObject(player);
            using (var response = await _httpClient.PostAsync("api/Player", new StringContent(json, Encoding.UTF8, "application/json")))
            {

                if (response.IsSuccessStatusCode)
                    return response.StatusCode.ToString();
                else
                    return response.RequestMessage.ToString();
            }
        }

        public async Task<string> PlayerTransfer(PlayerTransfer playerTransfer)
        {
            var json = JsonConvert.SerializeObject(playerTransfer);
            using (var response = await _httpClient.PostAsync("api/Player/Transfer", new StringContent(json, Encoding.UTF8, "application/json")))
            {

                if (response.IsSuccessStatusCode)
                    return response.StatusCode.ToString();
                else
                    return response.RequestMessage.ToString();
            }
        }

    }
}
