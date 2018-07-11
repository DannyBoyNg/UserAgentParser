using System.Collections.Generic;

namespace UserAgentParser
{
    public class UserAgent
    {
        private static Dictionary<string, UA> cache = new Dictionary<string, UA>();

        public static UA Parse(string userAgentString)
        {
            if (cache.ContainsKey(userAgentString)) return cache[userAgentString];
            var ua = new UA(userAgentString);
            cache.Add(userAgentString, ua);
            return ua;
        }
    }
}
