# UserAgentParser

A library to parse user-agent strings in C#.

## Dependancies

.Net Standard 2

## Installing

Install from Nuget
```
Install-Package DannyBoyNg.UserAgentParser
```

## Usage

```csharp
var ua = new UserAgent("Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0");

var isBrowser = ua.IsBrowser; // true
var isRobot = ua.IsRobot; // false
var isMobile = ua.IsMobile; // false

var platform = ua.Platform; // Windows 7
var bowser = ua.Browser; // Firefox
var version = ua.Version; // 47.0
var mobile = ua.Mobile; // empty string
var robot = ua.Robot; // empty string
```

When parsing an user-agent on every request in Asp Net Core. It would be recommended to implement Asp Net Core middleware.

## License

This project is licensed under the MIT License.

## Contributions

Contributions are welcome.
