using System;
using System.Text.Json;
using System.Threading.Tasks;
using Skinet.Service.Interfaces;
using StackExchange.Redis;

namespace Skinet.Data.Repository
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDatabase _database;

        public ResponseCacheService(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive)
        {
            if (response == null)
            {
                return;
            }
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var serialisedResponse = JsonSerializer.Serialize(response, options);

            await _database.StringSetAsync(cacheKey, serialisedResponse, timeToLive);
        }

        public async Task<string> GetCacheResponseAsync(string cachekey)
        {
            var cacheResponse = await _database.StringGetAsync(cachekey);

            if (string.IsNullOrEmpty(cacheResponse))
            {
                return null;
            }
            return cacheResponse;
        }
    }
}