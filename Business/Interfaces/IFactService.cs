using KittleData.Business.Models;
using System.Threading.Tasks;

namespace KittleData.Business.Interfaces
{
    public interface IFactService
    {
        Task<RandomCatFact> GetRandomCatFact();
    }
}
