using System;
using System.Threading.Tasks;

namespace Skinet.Service.Interfaces
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive);
        Task<string> GetCacheResponseAsync(string cachekey);
    }
}