# Performance logging [![NuGet Version](http://img.shields.io/nuget/v/PerformanceLogging.svg?style=flat)](https://www.nuget.org/packages/PerformanceLogging/)

Extensions and wrapper for default .NET ILogger. Designed to increase performance by more accurate work with strings.

This project, as well as the examples below, was inspired by [JetBrains.RD](https://github.com/JetBrains/rd/tree/master/rd-net/Lifetimes/Diagnostics) framework logging component.

Use extensions for short-lived services (common way):

```c#
using PerformanceLogging;

logger.Trace()?.Log("Message.");
logger.Debug()?.Log($"Message: {GetMessage()}.");
logger.Info()?.Log("Message: {message}.", "log message");
logger.Warn()?.Log("Message: {message}.", GetMessage());
logger.Error()?.Log("Message: {message}, {anotherMessage}.", "log message", GetMessage());
logger.Critical()?.Log("Message: part{part1}, part{part2}.", 1, 2);
```

or 

Wrap logger for long-lived reusable services and plenty of logging:

```c#
using PerformanceLogging;

var wrappedLogger = logger.Wrap();
wrappedLogger.Trace?.Log("Message.");
wrappedLogger.Debug?.Log($"Message: {GetMessage()}.");
wrappedLogger.Info?.Log("Message: {message}.", "log message");
wrappedLogger.Warn?.Log("Message: {message}.", GetMessage());
wrappedLogger.Error?.Log("Message: {message}, {anotherMessage}.", "log message", GetMessage());
wrappedLogger.Critical?.Log("Message: part{part1}, part{part2}.", 1, 2);
```

See also, some usage examples in [Demo](/Demo) folder.

## Benchmarks

#### Trace logging with specified log message (1000 log messages). 

See benchmark's full [report](/Benchmarks/Reports/Compare/TraceLogging.md) 
and [source](/Benchmarks/Benchmarks.Compare/TraceLogging.cs).

|                              Method | MinLogLevel |          Mean |      Error | Ratio |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------- |--------------:|-----------:|------:|--------:|------:|------:|----------:|
|                   **logger.LogTrace()** |           **Trace** | **142,469.45 ns** | **550.393 ns** |  **1.00** | **12.4512** |     **-** |     **-** |   **79200 B** |
| if(TraceEnabled){logger.LogTrace()} |           Trace | 157,030.51 ns | 604.003 ns |  1.10 | 12.4512 |     - |     - |   79200 B |
|               logger.Trace()?.Log() |           Trace | 154,799.17 ns | 399.695 ns |  1.09 | 12.4512 |     - |     - |   79200 B |
|          wrappedLogger.Trace?.Log() |           Trace | 153,710.00 ns | 336.233 ns |  1.08 | 12.4512 |     - |     - |   79200 B |
|                                     |                 |               |            |       |         |       |       |           |
|                   **logger.LogTrace()** |           **Debug** | **132,921.32 ns** | **459.185 ns** |  **1.00** | **12.4512** |     **-** |     **-** |   **79200 B** |
| if(TraceEnabled){logger.LogTrace()} |           Debug |   5,857.41 ns |  14.172 ns |  _0.04_ |       - |     - |     - |         - |
|               logger.Trace()?.Log() |           Debug |   6,783.43 ns |  14.028 ns |  _0.05_ |       - |     - |     - |         - |
|          wrappedLogger.Trace?.Log() |           Debug |   3,985.49 ns |  10.370 ns |  _0.03_ |       - |     - |     - |         - |

#### Trace logging with formatted log message (1000 log messages). 

See benchmark's full [report](/Benchmarks/Reports/Compare/TraceLoggingWithFormat.md) 
and [source](/Benchmarks/Benchmarks.Compare/TraceLoggingWithFormat.cs).

|                              Method | MinLogLevel |          Mean |       Error |      Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------- |--------------:|------------:|------:|-------:|------:|------:|----------:|
|                   **logger.LogTrace()** |           **Trace** | **84,242.975 ns** | **171.9278 ns** | **1.00** | **8.9111** |     **-** |     **-** |   **56000 B** |
| if(TraceEnabled){logger.LogTrace()} |           Trace | 92,538.049 ns | 158.2325 ns | 1.10 | 8.9111 |     - |     - |   56000 B |
|               logger.Trace()?.Log() |           Trace | 94,536.405 ns |  95.2812 ns | 1.12 | 8.9111 |     - |     - |   56000 B |
|          wrappedLogger.Trace?.Log() |           Trace | 87,847.457 ns | 103.4875 ns | 1.04 | 8.9111 |     - |     - |   56000 B |
|                                     |                 |               |             |      |        |       |       |           |
|                   **logger.LogTrace()** |           **Debug** | **73,142.684 ns** |  **98.5258 ns** |  **1.00** | **8.9111** |     **-** |     **-** |   **56000 B** |
| if(TraceEnabled){logger.LogTrace()} |           Debug |  6,137.874 ns |  27.6830 ns |  _0.08_ |      - |     - |     - |         - |
|               logger.Trace()?.Log() |           Debug |  6,365.255 ns |   5.6625 ns |  _0.09_ |      - |     - |     - |         - |
|          wrappedLogger.Trace?.Log() |           Debug |  5,210.616 ns |   3.4169 ns |  _0.07_ |      - |     - |     - |         - |
