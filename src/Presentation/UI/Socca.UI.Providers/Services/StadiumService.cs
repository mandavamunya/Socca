using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Socca.UI.Providers.DTOs;
using Socca.UI.Providers.Interfaces;

namespace Socca.UI.Providers.Services
{
    public class StadiumService: IStadiumService
    {
        private readonly HttpClient _httpClient;

        public StadiumService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> AddStadium(Stadium stadium)
        {
            var json = JsonConvert.SerializeObject(stadium);
            using (var response = await _httpClient.PostAsync("api/Stadium", new StringContent(json, Encoding.UTF8, "application/json")))
            {

                if (response.IsSuccessStatusCode)
                    return response.StatusCode.ToString();
                else
                    return response.RequestMessage.ToString();
            }
        }

        public async Task<List<Stadium>> GetStadiums()
        {
            using (var response = await _httpClient.GetAsync("api/Stadium"))
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Stadium>>(data);
            }
        }

    }
}
