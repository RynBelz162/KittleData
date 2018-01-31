using KittleData.Business.Models;
using System.Threading.Tasks;

namespace KittleData.Business.Interfaces
{
    public interface IGifService
    {
        Task<RandomCatGif> GetRandomGif();
    }
}
