``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.418 (1909/November2018Update/19H2)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.102
  [Host]     : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  DefaultJob : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT


```
|                              Method | LogLinesCount | MinimumLogLevel |          Mean |       Error |      StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------- |---------------- |--------------:|------------:|------------:|------:|-------:|------:|------:|----------:|
|                   **logger.LogTrace()** |             **1** |           **Trace** |     **89.308 ns** |   **0.1603 ns** |   **0.1339 ns** |  **1.00** | **0.0088** |     **-** |     **-** |      **56 B** |
| if(TraceEnabled){logger.LogTrace()} |             1 |           Trace |     93.888 ns |   0.1486 ns |   0.1390 ns |  1.05 | 0.0088 |     - |     - |      56 B |
|               logger.Trace()?.Log() |             1 |           Trace |    105.089 ns |   0.1655 ns |   0.1468 ns |  1.18 | 0.0088 |     - |     - |      56 B |
|          wrappedLogger.Trace?.Log() |             1 |           Trace |     92.821 ns |   0.2280 ns |   0.2021 ns |  1.04 | 0.0088 |     - |     - |      56 B |
|                                     |               |                 |               |             |             |       |        |       |       |           |
|                   **logger.LogTrace()** |             **1** |           **Debug** |     **73.557 ns** |   **0.1823 ns** |   **0.1705 ns** |  **1.00** | **0.0088** |     **-** |     **-** |      **56 B** |
| if(TraceEnabled){logger.LogTrace()} |             1 |           Debug |      5.891 ns |   0.0223 ns |   0.0208 ns |  0.08 |      - |     - |     - |         - |
|               logger.Trace()?.Log() |             1 |           Debug |     14.127 ns |   0.0429 ns |   0.0380 ns |  0.19 |      - |     - |     - |         - |
|          wrappedLogger.Trace?.Log() |             1 |           Debug |     12.010 ns |   0.0169 ns |   0.0150 ns |  0.16 |      - |     - |     - |         - |
|                                     |               |                 |               |             |             |       |        |       |       |           |
|                   **logger.LogTrace()** |            **10** |           **Trace** |    **841.569 ns** |   **2.1038 ns** |   **1.8649 ns** |  **1.00** | **0.0887** |     **-** |     **-** |     **560 B** |
| if(TraceEnabled){logger.LogTrace()} |            10 |           Trace |    952.013 ns |   5.0408 ns |   4.4685 ns |  1.13 | 0.0877 |     - |     - |     560 B |
|               logger.Trace()?.Log() |            10 |           Trace |  1,036.372 ns |   5.0297 ns |   4.4587 ns |  1.23 | 0.0877 |     - |     - |     560 B |
|          wrappedLogger.Trace?.Log() |            10 |           Trace |    920.979 ns |   1.7969 ns |   1.5005 ns |  1.09 | 0.0887 |     - |     - |     560 B |
|                                     |               |                 |               |             |             |       |        |       |       |           |
|                   **logger.LogTrace()** |            **10** |           **Debug** |    **730.923 ns** |   **1.8037 ns** |   **1.5989 ns** |  **1.00** | **0.0887** |     **-** |     **-** |     **560 B** |
| if(TraceEnabled){logger.LogTrace()} |            10 |           Debug |     66.853 ns |   0.3291 ns |   0.2917 ns |  0.09 |      - |     - |     - |         - |
|               logger.Trace()?.Log() |            10 |           Debug |     78.204 ns |   0.1093 ns |   0.0969 ns |  0.11 |      - |     - |     - |         - |
|          wrappedLogger.Trace?.Log() |            10 |           Debug |     59.062 ns |   0.2167 ns |   0.2027 ns |  0.08 |      - |     - |     - |         - |
|                                     |               |                 |               |             |             |       |        |       |       |           |
|                   **logger.LogTrace()** |           **100** |           **Trace** |  **8,359.951 ns** |  **12.0864 ns** |  **11.3056 ns** |  **1.00** | **0.8850** |     **-** |     **-** |    **5600 B** |
| if(TraceEnabled){logger.LogTrace()} |           100 |           Trace | 10,077.075 ns |   8.0034 ns |   7.0948 ns |  1.21 | 0.8850 |     - |     - |    5600 B |
|               logger.Trace()?.Log() |           100 |           Trace |  9,585.550 ns |  22.1976 ns |  19.6776 ns |  1.15 | 0.8850 |     - |     - |    5600 B |
|          wrappedLogger.Trace?.Log() |           100 |           Trace |  8,613.619 ns |  23.0954 ns |  21.6034 ns |  1.03 | 0.8850 |     - |     - |    5600 B |
|                                     |               |                 |               |             |             |       |        |       |       |           |
|                   **logger.LogTrace()** |           **100** |           **Debug** |  **7,185.043 ns** |   **9.2247 ns** |   **8.6288 ns** |  **1.00** | **0.8926** |     **-** |     **-** |    **5600 B** |
| if(TraceEnabled){logger.LogTrace()} |           100 |           Debug |    615.070 ns |   3.7136 ns |   3.4737 ns |  0.09 |      - |     - |     - |         - |
|               logger.Trace()?.Log() |           100 |           Debug |    650.941 ns |   1.7841 ns |   1.6689 ns |  0.09 |      - |     - |     - |         - |
|          wrappedLogger.Trace?.Log() |           100 |           Debug |    535.096 ns |   1.5014 ns |   1.3309 ns |  0.07 |      - |     - |     - |         - |
|                                     |               |                 |               |             |             |       |        |       |       |           |
|                   **logger.LogTrace()** |          **1000** |           **Trace** | **84,242.975 ns** | **171.9278 ns** | **160.8213 ns** |  **1.00** | **8.9111** |     **-** |     **-** |   **56000 B** |
| if(TraceEnabled){logger.LogTrace()} |          1000 |           Trace | 92,538.049 ns | 158.2325 ns | 140.2690 ns |  1.10 | 8.9111 |     - |     - |   56000 B |
|               logger.Trace()?.Log() |          1000 |           Trace | 94,536.405 ns |  95.2812 ns |  89.1261 ns |  1.12 | 8.9111 |     - |     - |   56000 B |
|          wrappedLogger.Trace?.Log() |          1000 |           Trace | 87,847.457 ns | 103.4875 ns |  91.7390 ns |  1.04 | 8.9111 |     - |     - |   56000 B |
|                                     |               |                 |               |             |             |       |        |       |       |           |
|                   **logger.LogTrace()** |          **1000** |           **Debug** | **73,142.684 ns** |  **98.5258 ns** |  **92.1611 ns** |  **1.00** | **8.9111** |     **-** |     **-** |   **56000 B** |
| if(TraceEnabled){logger.LogTrace()} |          1000 |           Debug |  6,137.874 ns |  27.6830 ns |  25.8947 ns |  0.08 |      - |     - |     - |         - |
|               logger.Trace()?.Log() |          1000 |           Debug |  6,365.255 ns |   5.6625 ns |   4.7284 ns |  0.09 |      - |     - |     - |         - |
|          wrappedLogger.Trace?.Log() |          1000 |           Debug |  5,210.616 ns |   3.4169 ns |   3.0290 ns |  0.07 |      - |     - |     - |         - |
