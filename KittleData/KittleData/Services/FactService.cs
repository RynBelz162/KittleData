using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using KittleData.Models;

namespace KittleData.Services
{
    public class FactService
    {
        private const string url = "https://the-cat-fact.herokuapp.com/api/randomfact";
        public async Task<RandomCatFact> GetRandomCatFact()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.Deserialize<RandomCatFact>(data, options);
            }
            return new RandomCatFact();
        }
    }
}
