# UserAgentParser

A library to parse user-agent strings in C#. UserAgentParser uses memoization for added performance.

## Dependancies

None

## Installing

Install from Nuget
```
Install-Package DannyBoyNg.UserAgentParser
```

## Usage

Basic

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

In AspNet Core

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
