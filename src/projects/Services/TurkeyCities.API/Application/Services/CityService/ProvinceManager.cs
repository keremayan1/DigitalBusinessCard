using TurkeyCities.API.Domain.Entities.Concrete;
using TurkeyCities.API.Domain.Entities.Models;

namespace TurkeyCities.API.Application.Services.CityService
{
    public class ProvinceManager : IProvinceService
    {
        private HttpClient _httpClient;
        private IConfiguration _configuration;


        public ProvinceManager(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<Province>> GetAll()
        {
            var client = await _httpClient.GetAsync("https://turkiyeapi.cyclic.app/api/v1/provinces");
            if (!client.IsSuccessStatusCode)
            {
                return null;
            }
            var response = await client.Content.ReadFromJsonAsync<ResponseModel<List<Province>>>();
            return response.Data;
        }

        public async Task<Province> GetByProvinceId(int id)
        {
            var client = await _httpClient.GetAsync($"https://turkiyeapi.cyclic.app/api/v1/provinces/{id}");
            if (!client.IsSuccessStatusCode)
            {
                return null;
            }
            var response = await client.Content.ReadFromJsonAsync<ResponseModel<Province>>();
            return response.Data;
        }
    }
}
