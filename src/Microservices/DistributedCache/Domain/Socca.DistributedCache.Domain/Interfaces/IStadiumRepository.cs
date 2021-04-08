using System.Threading.Tasks;
using Socca.DistributedCache.Domain.Entities;

namespace Socca.DistributedCache.Domain.Interfaces
{
    public interface IStadiumRepository
    {
        Task<Stadium> GetStadium(string name);
        Task<Stadium> UpdateStadium(Stadium stadium);
        Task DeleteStadium(string name);
    }
}
