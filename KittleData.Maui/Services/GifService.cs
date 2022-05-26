using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using KittleData.Maui.Models;

namespace KittleData.Maui.Services;

public class GifService
{
    private readonly HttpClient _client;

    public GifService(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = new Uri("https://thecatapi.com/api/images/");
    }

    public async Task<RandomCatGif> GetRandomGif()
    {
        var response = await _client.GetAsync("get?type=gif");
        if (!response.IsSuccessStatusCode)
        {
            return new RandomCatGif(null, null);
        }

        var sourceUrl = response.RequestMessage?.RequestUri;
        var gifStream = await response.Content.ReadAsStreamAsync();
        var retStream = new MemoryStream();
        gifStream.CopyTo(retStream);

        return new RandomCatGif(sourceUrl, retStream.ToArray());
    }
}