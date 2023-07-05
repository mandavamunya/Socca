using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Socca.DistributedCache.Domain.Interfaces;

namespace Socca.DistributedCache.Data.Context
{
    public class DistributedCacheRepository<D>: IDistributedCacheRepository<D>
    {
        private readonly IDistributedCache _cache;

        public DistributedCacheRepository(IDistributedCache cache)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task Delete(string key)
        {
            await _cache.RemoveAsync(key);
        }

        public async Task<D> Get(string key)                                                                                            
        {
            var cachedObject = await _cache.GetStringAsync(key);
            return (string.IsNullOrEmpty(cachedObject)) ? default: JsonConvert.DeserializeObject<D>(cachedObject);
        }

        public async Task<D> Update(string key, D value)
        {
            var options = new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(DateTimeOffset.Now.AddDays(1)) // indicates whether a cache entry should be evicted at a specified point in time.
            .SetSlidingExpiration(TimeSpan.FromDays(0.5));

            var cacheObject = JsonConvert.SerializeObject(value);
            await _cache.SetStringAsync(key, cacheObject, options);
            return await Get(key);
        }
    }
}
