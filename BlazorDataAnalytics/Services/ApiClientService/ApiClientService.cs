
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
//using BlazorDataAnalytics.Models;
using Persistence.Config.Entities;


namespace BlazorDataAnalytics.Services.ApiClientService
{
    public class ApiClientService: IApiClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiClientService(IHttpClientFactory httpClientfactory)
        {
            _httpClientFactory = httpClientfactory;
        }

        public async Task<UserTrack> GetUserIPAsync()
        {
            var client = _httpClientFactory.CreateClient("IP");
            return await client.GetFromJsonAsync<UserTrack>("/");
        }
    }
}
