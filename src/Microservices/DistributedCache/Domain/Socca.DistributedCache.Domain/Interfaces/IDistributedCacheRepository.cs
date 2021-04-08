using System.Threading.Tasks;

namespace Socca.DistributedCache.Domain.Interfaces
{
    public interface IDistributedCacheRepository<D>
    {
        Task<D> Get(string key);
        Task<D> Update(string key, D cacheObject);
        Task Delete(string key);
    }
}
