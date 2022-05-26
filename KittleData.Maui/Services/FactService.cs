using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using KittleData.Maui.Models;

namespace KittleData.Maui.Services;

public class FactService
{
    private readonly HttpClient _client;

    public FactService(HttpClient client)
    {
        _client = client;

        _client.BaseAddress = new Uri("https://the-cat-fact.herokuapp.com/api/");
    }

    public async Task<RandomCatFact> GetRandomCatFact()
    {
        var response = await _client.GetAsync("randomfact");
        if (!response.IsSuccessStatusCode)
        {
            return new RandomCatFact();
        }

        var data = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<RandomCatFact>(data, options) ?? new RandomCatFact();
    }
}