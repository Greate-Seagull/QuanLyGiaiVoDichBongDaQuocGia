using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.Manager
{
    public class CacheManager
    {
        public static ObjectCache cache = MemoryCache.Default;

        public static void Add<T>(string key, T value, int expirationMinutes = 30)
        {
            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(expirationMinutes) };
            cache.Set(key, value, policy);
        }

        public static T Get<T>(string key)
        {
            return cache[key] is T value ? value : default;
        }

        public static T GetOrLoad<T>(string key, Func<T> loadFunction, int expirationMinutes = 30)
        {
            var value = Get<T>(key);
            if (value == null)
            {
                value = loadFunction();
                Add(key, value, expirationMinutes);
            }

            return value;
        }    

        public static void Remove(string key)
        {
            cache.Remove(key);
        }
    }
}
