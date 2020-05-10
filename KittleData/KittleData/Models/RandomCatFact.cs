using System.Collections.Generic;

namespace KittleData.Models
{
    public class RandomCatFact
    {
        public string Status { get; set; }
        public List<CatFact> Data { get; set; }
        public string Message { get; set; }
    }
}
