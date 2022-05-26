using System.Collections.Generic;

namespace KittleData.Maui.Models;

public class RandomCatFact
{
    public string Status { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
    public ICollection<CatFact> Data { get; init; } = new List<CatFact>(); 
}