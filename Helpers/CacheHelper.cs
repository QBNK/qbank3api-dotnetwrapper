using System;
using System.Web;

namespace QBankApi.Helpers
{
    //HttpContext.Current crashes in NUnit tests

    internal class CacheHelper
    {
        public static void Add<T>(T o, string key, int cacheExpirationMinutes) where T : class
        {
            HttpRuntime.Cache.Insert(key, o, null, DateTime.Now.AddMinutes(cacheExpirationMinutes),
                System.Web.Caching.Cache.NoSlidingExpiration);
        }

        public static void Clear(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }

        public static bool Exists(string key)
        {
            return HttpRuntime.Cache[key] != null;
        }

        public static T Get<T>(string key) where T : class
        {
            try
            {
                return (T) HttpRuntime.Cache[key];
            }
            catch
            {
                return null;
            }
        }
    }
}