using KittleData.Business.Interfaces;
using KittleData.Business.Models;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace KittleData.Business.Services
{
    public class GifService : IGifService
    {
        private const string url = "http://thecatapi.com/api/images/get?type=gif";
        public async Task<RandomCatGif> GetRandomGif()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var sourceUrl = response.RequestMessage.RequestUri;
                var gifStream = await response.Content.ReadAsStreamAsync();
                var retStream = new MemoryStream();
                gifStream.CopyTo(retStream);
                return new RandomCatGif { SourceUrl = sourceUrl, Gif = retStream.ToArray() };
            }
            return new RandomCatGif();
        }
    }
}
