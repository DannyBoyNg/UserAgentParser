using Microsoft.Extensions.Caching.Memory;
using System;

namespace UserAgentParser
{
    public class UserAgent
    {
        private static MemoryCacheOptions cacheOptions = new MemoryCacheOptions();
        private static IMemoryCache cache = new MemoryCache(new MemoryCacheOptions());

        public UserAgent()
        {
            cacheOptions.SizeLimit = 10000;
        }

        public static UA Parse(string userAgentString)
        {
            userAgentString = (userAgentString.Length > 512) ? userAgentString.Trim().Substring(0, 512) : userAgentString.Trim();
            return cache.GetOrCreate(userAgentString, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromDays(3);
                entry.Size = 1;
                return new UA(userAgentString);
            });
        }

        public UA ParseUserAgent(string userAgentString)
        {
            userAgentString = (userAgentString.Length > 512) ? userAgentString.Trim().Substring(0, 512) : userAgentString.Trim();
            return cache.GetOrCreate(userAgentString, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromDays(3);
                entry.Size = 1;
                return new UA(userAgentString);
            });
        }

    }
}
