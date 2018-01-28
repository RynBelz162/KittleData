using KittleData.Business.Interfaces;
using KittleData.Business.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace KittleData.Business.Services
{
    public class FactService : IFactService
    {
        private const string url = "https://the-cat-fact.herokuapp.com/api/randomfact";
        public async Task<RandomCatFact> GetRandomCatFact()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RandomCatFact>(data);
            }
            return new RandomCatFact();
        }
    }
}
