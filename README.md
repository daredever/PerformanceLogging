# NullableLogger [![NuGet Version](http://img.shields.io/nuget/v/NullableLogger.svg?style=flat)](https://www.nuget.org/packages/NullableLogger/)
DotNet logger wrapper for increase performance by more accurate works with strings.

## Summary
Project inspired by [JetBrains.RD](https://github.com/JetBrains/rd/tree/master/rd-net/Lifetimes/Diagnostics) framework logging component.

**NullableLogger** usage example see at [DemoApp](/Demo/DemoApp) project.

## Usage
Extensions:

```c#
using NullableLogger;

logger.Trace()?.Log($"message: {GetMessage()}.");
logger.Debug()?.Log($"message: {GetMessage()}.");
logger.Info()?.Log($"message: {GetMessage()}.");
logger.Warn()?.Log($"message: {GetMessage()}.");
logger.Error()?.Log($"message: {GetMessage()}.");
logger.Critical()?.Log($"message: {GetMessage()}.");
```

or 

Wrap:

```c#
using NullableLogger;

var wrappedLogger = logger.Wrap();
wrappedLogger.Trace?.Log($"message: {GetMessage()}.");
wrappedLogger.Debug?.Log($"message: {GetMessage()}.");
wrappedLogger.Info?.Log($"message: {GetMessage()}.");
wrappedLogger.Warn?.Log($"message: {GetMessage()}.");
wrappedLogger.Error?.Log($"message: {GetMessage()}.");
wrappedLogger.Critical?.Log($"message: {GetMessage()}.");
```
