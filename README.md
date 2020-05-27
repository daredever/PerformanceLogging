# NullableLogger [![NuGet Version](http://img.shields.io/nuget/v/NullableLogger.svg?style=flat)](https://www.nuget.org/packages/NullableLogger/)
DotNet logger wrapper for increase performance by more accurate works with strings.

## Summary
Project inspired by [JetBrains.RD](https://github.com/JetBrains/rd/tree/master/rd-net/Lifetimes/Diagnostics) framework logging component.

**NullableLogger** usage example see at [DemoApp](/Demo/DemoApp) project.

## Usage
Extensions:

```c#
using NullableLogger;

logger.Trace()?.Log("Message");
logger.Debug()?.Log("Message");
logger.Info()?.Log("Message");
logger.Warn()?.Log("Message");
logger.Error()?.Log("Message");
logger.Critical()?.Log("Message");
```

or 

Wrap:

```c#
using NullableLogger;

var wrappedLogger = logger.Wrap();
wrappedLogger.Trace?.Log("Message");
wrappedLogger.Debug?.Log("Message");
wrappedLogger.Info?.Log("Message");
wrappedLogger.Warn?.Log("Message");
wrappedLogger.Error?.Log("Message");
wrappedLogger.Critical?.Log("Message");
```
