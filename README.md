## DannyBoyNg.UserAgentParser is now DEPRECATED in favor of DannyBoyNg.UserAgentService. 

# UserAgentParser

A library to parse user-agent strings in C#. UserAgentParser uses memoization for added performance. Caching will not store more than 10.000 different user agent strings to prevent memory leaks.

## Dependancies

Microsoft.Extensions.Caching.Memory/IMemoryCache

## Installing

Install from Nuget
```
Install-Package DannyBoyNg.UserAgentParser
```

## Usage

Calling parse method as a static method

```csharp
using UserAgentParser;
...
var ua = UserAgent.Parse("Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0");

var isBrowser = ua.IsBrowser; // true
var isRobot = ua.IsRobot; // false
var isMobile = ua.IsMobile; // false

var platform = ua.Platform; // Windows 7
var bowser = ua.Browser; // Firefox
var version = ua.BrowserVersion; // 47.0
var mobile = ua.Mobile; // empty string
var robot = ua.Robot; // empty string
```

Calling parse method as an instance method

```csharp
using UserAgentParser;
...
var userAgent = new UserAgent();
var ua = userAgent.ParseUserAgent("Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0");
```

In AspNet Core
Get user agent string
```csharp
var userAgentString = Request.Headers["User-Agent"].ToString();
```

Register with dependency injection in Startup.cs (you don't need to register with DI if you call the static parse method)
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<UserAgent>(); //UserAgent gets instanciated once for every request

    or

    services.AddSingleton<UserAgent>(); //UserAgent gets instanciated once until server restarts
}
```

Inject UserAgent into a Controller
```csharp
using UserAgentParser;
...
public class MyController
{
    public MyController(UserAgent userAgent)
    {
        var userAgentString = Request.Headers["User-Agent"].ToString();
        var ua = userAgent.ParseUserAgent(userAgentString);
    }
}
```

Or call static parse method and forget about DI. No need to register with DI or inject UserAgent into your Controller.
```csharp
using UserAgentParser;
...
var userAgentString = Request.Headers["User-Agent"].ToString();
var ua = UserAgent.Parse(userAgentString);
```

## License

This project is licensed under the MIT License.

## Contributions

Contributions are welcome.
