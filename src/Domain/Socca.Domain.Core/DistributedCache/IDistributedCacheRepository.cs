using System.Threading.Tasks;

namespace Socca.Domain.Core.DistributedCache
{
    public interface IDistributedCacheRepository<T, D>
    {
        Task<D> Get(T key);
        Task<D> Update(D player);
        Task Delete(T key);
    }
}
