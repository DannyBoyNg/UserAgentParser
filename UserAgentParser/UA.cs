﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UserAgentParser
{
    public class UA
    {
        internal static readonly Dictionary<string, string> platforms = new Dictionary<string, string>() {
            {"windows nt 10.0", "Windows 10"},
            {"windows nt 6.3", "Windows 8.1"},
            {"windows nt 6.2", "Windows 8"},
            {"windows nt 6.1", "Windows 7"},
            {"windows nt 6.0", "Windows Vista"},
            {"windows nt 5.2", "Windows 2003"},
            {"windows nt 5.1", "Windows XP"},
            {"windows nt 5.0", "Windows 2000"},
            {"windows nt 4.0", "Windows NT 4.0"},
            {"winnt4.0", "Windows NT 4.0"},
            {"winnt 4.0", "Windows NT"},
            {"winnt", "Windows NT"},
            {"windows 98", "Windows 98"},
            {"win98", "Windows 98"},
            {"windows 95", "Windows 95"},
            {"win95", "Windows 95"},
            {"windows phone", "Windows Phone"},
            {"windows", "Unknown Windows OS"},
            {"android", "Android"},
            {"blackberry", "BlackBerry"},
            {"iphone", "iOS"},
            {"ipad", "iOS"},
            {"ipod", "iOS"},
            {"os x", "Mac OS X"},
            {"ppc mac", "Power PC Mac"},
            {"freebsd", "FreeBSD"},
            {"ppc", "Macintosh"},
            {"linux", "Linux"},
            {"debian", "Debian"},
            {"sunos", "Sun Solaris"},
            {"beos", "BeOS"},
            {"apachebench", "ApacheBench"},
            {"aix", "AIX"},
            {"irix", "Irix"},
            {"osf", "DEC OSF"},
            {"hp-ux", "HP-UX"},
            {"netbsd", "NetBSD"},
            {"bsdi", "BSDi"},
            {"openbsd", "OpenBSD"},
            {"gnu", "GNU/Linux"},
            {"unix", "Unknown Unix OS"},
            {"symbian", "Symbian OS"},
        };

        internal static readonly Dictionary<string, string> browsers = new Dictionary<string, string>()
        {
            {"OPR", "Opera"},
            {"Flock", "Flock"},
            {"Edge", "Spartan"},
            {"Chrome", "Chrome"},
            {"Opera.*?Version", "Opera"},
            {"Opera", "Opera"},
            {"MSIE", "Internet Explorer"},
            {"Internet Explorer", "Internet Explorer"},
            {"Trident.* rv" , "Internet Explorer"},
            {"Shiira", "Shiira"},
            {"Firefox", "Firefox"},
            {"Chimera", "Chimera"},
            {"Phoenix", "Phoenix"},
            {"Firebird", "Firebird"},
            {"Camino", "Camino"},
            {"Netscape", "Netscape"},
            {"OmniWeb", "OmniWeb"},
            {"Safari", "Safari"},
            {"Mozilla", "Mozilla"},
            {"Konqueror", "Konqueror"},
            {"icab", "iCab"},
            {"Lynx", "Lynx"},
            {"Links", "Links"},
            {"hotjava", "HotJava"},
            {"amaya", "Amaya"},
            {"IBrowse", "IBrowse"},
            {"Maxthon", "Maxthon"},
            {"Ubuntu", "Ubuntu Web Browser"},
        };

        internal static readonly Dictionary<string, string> mobiles = new Dictionary<string, string>()
        {
            // Legacy
            {"mobileexplorer", "Mobile Explorer"},
            {"palmsource", "Palm"},
            {"palmscape", "Palmscape"},
            // Phones and Manufacturers
            {"motorola", "Motorola"},
            {"nokia", "Nokia"},
            {"palm", "Palm"},
            {"iphone", "Apple iPhone"},
            {"ipad", "iPad"},
            {"ipod", "Apple iPod Touch"},
            {"sony", "Sony Ericsson"},
            {"ericsson", "Sony Ericsson"},
            {"blackberry", "BlackBerry"},
            {"cocoon", "O2 Cocoon"},
            {"blazer", "Treo"},
            {"lg", "LG"},
            {"amoi", "Amoi"},
            {"xda", "XDA"},
            {"mda", "MDA"},
            {"vario", "Vario"},
            {"htc", "HTC"},
            {"samsung", "Samsung"},
            {"sharp", "Sharp"},
            {"sie-", "Siemens"},
            {"alcatel", "Alcatel"},
            {"benq", "BenQ"},
            {"ipaq", "HP iPaq"},
            {"mot-", "Motorola"},
            {"playstation portable", "PlayStation Portable"},
            {"playstation 3", "PlayStation 3"},
            {"playstation vita", "PlayStation Vita"},
            {"hiptop", "Danger Hiptop"},
            {"nec-", "NEC"},
            {"panasonic", "Panasonic"},
            {"philips", "Philips"},
            {"sagem", "Sagem"},
            {"sanyo", "Sanyo"},
            {"spv", "SPV"},
            {"zte", "ZTE"},
            {"sendo", "Sendo"},
            {"nintendo dsi", "Nintendo DSi"},
            {"nintendo ds", "Nintendo DS"},
            {"nintendo 3ds", "Nintendo 3DS"},
            {"wii", "Nintendo Wii"},
            {"open web", "Open Web"},
            {"openweb", "OpenWeb"},
            // Operating Systems
            {"android", "Android"},
            {"symbian", "Symbian"},
            {"SymbianOS", "SymbianOS"},
            {"elaine", "Palm"},
            {"series60", "Symbian S60"},
            {"windows ce", "Windows CE"},
            // Browsers
            {"obigo", "Obigo"},
            {"netfront", "Netfront Browser"},
            {"openwave", "Openwave Browser"},
            {"mobilexplorer", "Mobile Explorer"},
            {"operamini", "Opera Mini"},
            {"opera mini", "Opera Mini"},
            {"opera mobi", "Opera Mobile"},
            {"fennec", "Firefox Mobile"},
            // Other
            {"digital paths", "Digital Paths"},
            {"avantgo", "AvantGo"},
            {"xiino", "Xiino"},
            {"novarra", "Novarra Transcoder"},
            {"vodafone", "Vodafone"},
            {"docomo", "NTT DoCoMo"},
            {"o2", "O2"},
            // Fallback
            {"mobile", "Generic Mobile"},
            {"wireless", "Generic Mobile"},
            {"j2me", "Generic Mobile"},
            {"midp", "Generic Mobile"},
            {"cldc", "Generic Mobile"},
            {"up.link", "Generic Mobile"},
            {"up.browser", "Generic Mobile"},
            {"smartphone", "Generic Mobile"},
            {"cellphone", "Generic Mobile"},
        };

        internal static readonly Dictionary<string, string> robots = new Dictionary<string, string>()
        {
            {"googlebot", "Googlebot"},
            {"msnbot", "MSNBot"},
            {"baiduspider", "Baiduspider"},
            {"bingbot", "Bing"},
            {"slurp", "Inktomi Slurp"},
            {"yahoo", "Yahoo"},
            {"ask jeeves", "Ask Jeeves"},
            {"fastcrawler", "FastCrawler"},
            {"infoseek", "InfoSeek Robot 1.0"},
            {"lycos", "Lycos"},
            {"yandex", "YandexBot"},
            {"mediapartners-google", "MediaPartners Google"},
            {"CRAZYWEBCRAWLER", "Crazy Webcrawler"},
            {"adsbot-google", "AdsBot Google"},
            {"feedfetcher-google", "Feedfetcher Google"},
            {"curious george", "Curious George"},
            {"ia_archiver", "Alexa Crawler"},
            {"MJ12bot", "Majestic-12"},
            {"Uptimebot", "Uptimebot"},
        };

        protected string _Agent = null;
        public bool IsBrowser { get; set; } = false;
        public bool IsRobot { get; set; } = false;
        public bool IsMobile { get; set; } = false;

        // Current values
        public string Platform { get; set; } = "";
        public string Browser { get; set; } = "";
        public string BrowserVersion { get; set; } = "";
        public string Mobile { get; set; } = "";
        public string Robot { get; set; } = "";

        internal UA(string userAgentString = null)
        {
            if (userAgentString != null)
            {
                _Agent = userAgentString.Trim();
                SetPlatform();
                if (SetRobot()) return;
                if (SetBrowser()) return;
                if (SetMobile()) return;
            }
        }

        internal bool SetPlatform()
        {
            foreach (var item in platforms)
            {
                if (Regex.IsMatch(_Agent, $"{Regex.Escape(item.Key)}", RegexOptions.IgnoreCase))
                {
                    Platform = item.Value;
                    return true;
                }
            }
            Platform = "Unknown Platform";
            return false;
        }

        internal bool SetBrowser()
        {
            foreach (var item in browsers)
            {
                var match = Regex.Match(_Agent, $@"{item.Key}.*?([0-9\.]+)", RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    IsBrowser = true;
                    BrowserVersion = match.Groups[1].Value;
                    Browser = item.Value;
                    SetMobile();
                    return true;
                }
            }
            return false;
        }

        internal bool SetRobot()
        {
            foreach (var item in robots)
            {
                if (Regex.IsMatch(_Agent, $"{Regex.Escape(item.Key)}", RegexOptions.IgnoreCase))
                {
                    IsRobot = true;
                    Robot = item.Value;
                    SetMobile();
                    return true;
                }
            }
            return false;
        }

        internal bool SetMobile()
        {
            foreach (var item in mobiles)
            {
                if (_Agent.IndexOf(item.Key, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    IsMobile = true;
                    Mobile = item.Value;
                    return true;
                }
            }
            return false;
        }

    }
}
