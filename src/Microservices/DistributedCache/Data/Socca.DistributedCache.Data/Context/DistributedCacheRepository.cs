using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Socca.DistributedCache.Domain.Interfaces;

namespace Socca.DistributedCache.Data.Context
{
    public class DistributedCacheRepository<D>: IDistributedCacheRepository<D>
    {
        private readonly IDistributedCache _redisCache;

        public DistributedCacheRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task Delete(string key)
        {
            await _redisCache.RemoveAsync(key);
        }

        public async Task<D> Get(string key)
        {
            var cachedObject = await _redisCache.GetStringAsync(key);
            if (string.IsNullOrEmpty(cachedObject))
                return default;
            return JsonConvert.DeserializeObject<D>(cachedObject);
        }

        public async Task<D> Update(string key, D cacheObject)
        {
            await _redisCache.SetStringAsync(key, JsonConvert.SerializeObject(cacheObject));
            return await Get(key);
        }
    }
}
