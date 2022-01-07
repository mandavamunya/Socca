using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Socca.UI.Providers.DTOs;
using Socca.UI.Providers.Interfaces;

namespace Socca.UI.Providers.Services
{
    public class FootballClubService: IFootballClubService
    {

        private readonly HttpClient _httpClient;

        public FootballClubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FootballClub>> GetFootballClubs()
        {
            // ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            using (var response = await _httpClient.GetAsync("api/FootballClub/"))
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<FootballClub>>(data);
            }
        }


        public async Task<string> AddFootballClubs(FootballClub footballClub)
        {
            var json = JsonConvert.SerializeObject(footballClub);
            using (var response = await _httpClient.PostAsync("api/FootballClub", new StringContent(json, Encoding.UTF8, "application/json")))
            {
                if (response.IsSuccessStatusCode)
                    return response.StatusCode.ToString();
                else
                    return response.RequestMessage.ToString();
            }
        }

        public async Task<string> LinkToStadium(AssignToStadium assignToStadium)
        {
            var json = JsonConvert.SerializeObject(assignToStadium);
            using (var response = await _httpClient.PostAsync("api/FootballClub/LinkToStadium", new StringContent(json, Encoding.UTF8, "application/json")))
            {
                if (response.IsSuccessStatusCode)
                    return response.StatusCode.ToString();
                else
                    return response.RequestMessage.ToString();
            }
        }


    }
}
