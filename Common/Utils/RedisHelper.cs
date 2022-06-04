using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Serilog;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public static class RedisHelper
    {
        public static async Task Save(this IDistributedCache cache, string key, object value, int expirationTime = 60)
        {
            try
            {
                await cache.SetStringAsync(key, JsonConvert.SerializeObject(value),
                        new DistributedCacheEntryOptions()
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(expirationTime)
                        });
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }

        public static async Task<T> Load<T>(this IDistributedCache cache, string key)
        {
            try
            {
                var data = await cache.GetStringAsync(key);
                if(!string.IsNullOrEmpty(data))
                    return JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

            return default(T);
        }

        //public static async Task RemoveCacheResponeAsync(this IDistributedCache cache,  IConnectionMultiplexer connectionMultiplexer, string pattern)
        //{
        //    if(string.IsNullOrEmpty(pattern)) throw new ArgumentNullException("Value cannot be null or whitespace");
        //    await foreach(var key in GetKeyAsync(connectionMultiplexer, "*" + pattern + "*"))
        //    {
        //        await cache.RemoveAsync(key);
        //    }
        //}

        //private async static IAsyncEnumerable<string> GetKeyAsync(IConnectionMultiplexer connectionMultiplexer, string pattern)
        //{          
        //    if (string.IsNullOrEmpty(pattern)) throw new ArgumentNullException("Value cannot be null or whitespace");
        //    foreach (var endPoint in connectionMultiplexer.GetEndPoints())
        //    {
        //        var server = connectionMultiplexer.GetServer(endPoint);
        //        foreach (var key in server.Keys(pattern: pattern))
        //        {
        //            yield return key;
        //        }
        //    }
        //}

    }
}
