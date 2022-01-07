using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Socca.UI.Providers.DTOs;
using Socca.UI.Providers.Interfaces;

namespace Socca.UI.Providers.Services
{
    public class PlayerTransferService: IPlayerTransferService
    {
        private readonly HttpClient _httpClient;
        private readonly IDistributedCacheService _distributedCacheService;

        public PlayerTransferService(HttpClient httpClient, IDistributedCacheService distributedCacheService)
        {
            _distributedCacheService = distributedCacheService;
            _httpClient = httpClient;
        }

        public async Task<PlayerTransfer> GetPlayerTransfer(int key)
        {
            var cachedObject = await _distributedCacheService.GetPlayerTransfer(key);
            if (cachedObject == null)
            {
                using (var response = await _httpClient.GetAsync($"api/PlayerTransfer/{key}"))
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PlayerTransfer>(data);
                }
            }
            return cachedObject;
        }

        public async Task<List<PlayerTransfer>> GetPlayerTransfers()
        {
            using (var response = await _httpClient.GetAsync("api/PlayerTransfer"))
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<PlayerTransfer>>(data);
            }
        }

    }
}
