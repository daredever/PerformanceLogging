``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.418 (1909/November2018Update/19H2)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.102
  [Host]     : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  DefaultJob : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT


```
|                              Method | LogLinesCount | MinimumLogLevel |          Mean |      Error |     StdDev | Ratio |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------- |---------------- |--------------:|-----------:|-----------:|------:|--------:|------:|------:|----------:|
|                   **logger.LogTrace()** |             **1** |           **Trace** |     **146.79 ns** |   **0.422 ns** |   **0.374 ns** |  **1.00** |  **0.0114** |     **-** |     **-** |      **72 B** |
| if(TraceEnabled){logger.LogTrace()} |             1 |           Trace |     160.01 ns |   0.689 ns |   0.611 ns |  1.09 |  0.0114 |     - |     - |      72 B |
|               logger.Trace()?.Log() |             1 |           Trace |     167.30 ns |   0.599 ns |   0.560 ns |  1.14 |  0.0114 |     - |     - |      72 B |
|          wrappedLogger.Trace?.Log() |             1 |           Trace |     158.87 ns |   0.366 ns |   0.342 ns |  1.08 |  0.0114 |     - |     - |      72 B |
|                                     |               |                 |               |            |            |       |         |       |       |           |
|                   **logger.LogTrace()** |             **1** |           **Debug** |     **138.16 ns** |   **0.275 ns** |   **0.244 ns** |  **1.00** |  **0.0114** |     **-** |     **-** |      **72 B** |
| if(TraceEnabled){logger.LogTrace()} |             1 |           Debug |      13.53 ns |   0.168 ns |   0.149 ns |  0.10 |       - |     - |     - |         - |
|               logger.Trace()?.Log() |             1 |           Debug |      14.36 ns |   0.100 ns |   0.093 ns |  0.10 |       - |     - |     - |         - |
|          wrappedLogger.Trace?.Log() |             1 |           Debug |      11.16 ns |   0.027 ns |   0.023 ns |  0.08 |       - |     - |     - |         - |
|                                     |               |                 |               |            |            |       |         |       |       |           |
|                   **logger.LogTrace()** |            **10** |           **Trace** |   **1,401.66 ns** |   **5.501 ns** |   **5.146 ns** |  **1.00** |  **0.1144** |     **-** |     **-** |     **720 B** |
| if(TraceEnabled){logger.LogTrace()} |            10 |           Trace |   1,494.08 ns |   2.662 ns |   2.490 ns |  1.07 |  0.1144 |     - |     - |     720 B |
|               logger.Trace()?.Log() |            10 |           Trace |   1,573.97 ns |   3.107 ns |   2.754 ns |  1.12 |  0.1144 |     - |     - |     720 B |
|          wrappedLogger.Trace?.Log() |            10 |           Trace |   1,468.29 ns |   4.380 ns |   3.883 ns |  1.05 |  0.1144 |     - |     - |     720 B |
|                                     |               |                 |               |            |            |       |         |       |       |           |
|                   **logger.LogTrace()** |            **10** |           **Debug** |   **1,301.90 ns** |   **1.901 ns** |   **1.778 ns** |  **1.00** |  **0.1144** |     **-** |     **-** |     **720 B** |
| if(TraceEnabled){logger.LogTrace()} |            10 |           Debug |      72.71 ns |   0.174 ns |   0.163 ns |  0.06 |       - |     - |     - |         - |
|               logger.Trace()?.Log() |            10 |           Debug |      84.04 ns |   0.063 ns |   0.059 ns |  0.06 |       - |     - |     - |         - |
|          wrappedLogger.Trace?.Log() |            10 |           Debug |      47.19 ns |   0.040 ns |   0.035 ns |  0.04 |       - |     - |     - |         - |
|                                     |               |                 |               |            |            |       |         |       |       |           |
|                   **logger.LogTrace()** |           **100** |           **Trace** |  **14,290.39 ns** |  **31.348 ns** |  **29.323 ns** |  **1.00** |  **1.1292** |     **-** |     **-** |    **7200 B** |
| if(TraceEnabled){logger.LogTrace()} |           100 |           Trace |  15,045.85 ns |  34.801 ns |  30.850 ns |  1.05 |  1.1444 |     - |     - |    7200 B |
|               logger.Trace()?.Log() |           100 |           Trace |  15,364.58 ns |  21.837 ns |  20.426 ns |  1.08 |  1.1444 |     - |     - |    7200 B |
|          wrappedLogger.Trace?.Log() |           100 |           Trace |  14,816.20 ns |  40.207 ns |  37.610 ns |  1.04 |  1.1444 |     - |     - |    7200 B |
|                                     |               |                 |               |            |            |       |         |       |       |           |
|                   **logger.LogTrace()** |           **100** |           **Debug** |  **12,947.60 ns** |  **59.325 ns** |  **55.492 ns** |  **1.00** |  **1.1444** |     **-** |     **-** |    **7200 B** |
| if(TraceEnabled){logger.LogTrace()} |           100 |           Debug |     599.93 ns |   0.963 ns |   0.854 ns |  0.05 |       - |     - |     - |         - |
|               logger.Trace()?.Log() |           100 |           Debug |     646.24 ns |   1.672 ns |   1.564 ns |  0.05 |       - |     - |     - |         - |
|          wrappedLogger.Trace?.Log() |           100 |           Debug |     456.73 ns |   0.867 ns |   0.724 ns |  0.04 |       - |     - |     - |         - |
|                                     |               |                 |               |            |            |       |         |       |       |           |
|                   **logger.LogTrace()** |          **1000** |           **Trace** | **142,469.45 ns** | **550.393 ns** | **487.909 ns** |  **1.00** | **12.4512** |     **-** |     **-** |   **79200 B** |
| if(TraceEnabled){logger.LogTrace()} |          1000 |           Trace | 157,030.51 ns | 604.003 ns | 471.566 ns |  1.10 | 12.4512 |     - |     - |   79200 B |
|               logger.Trace()?.Log() |          1000 |           Trace | 154,799.17 ns | 399.695 ns | 333.764 ns |  1.09 | 12.4512 |     - |     - |   79200 B |
|          wrappedLogger.Trace?.Log() |          1000 |           Trace | 153,710.00 ns | 336.233 ns | 314.512 ns |  1.08 | 12.4512 |     - |     - |   79200 B |
|                                     |               |                 |               |            |            |       |         |       |       |           |
|                   **logger.LogTrace()** |          **1000** |           **Debug** | **132,921.32 ns** | **459.185 ns** | **429.522 ns** |  **1.00** | **12.4512** |     **-** |     **-** |   **79200 B** |
| if(TraceEnabled){logger.LogTrace()} |          1000 |           Debug |   5,857.41 ns |  14.172 ns |  12.563 ns |  0.04 |       - |     - |     - |         - |
|               logger.Trace()?.Log() |          1000 |           Debug |   6,783.43 ns |  14.028 ns |  12.436 ns |  0.05 |       - |     - |     - |         - |
|          wrappedLogger.Trace?.Log() |          1000 |           Debug |   3,985.49 ns |  10.370 ns |   9.700 ns |  0.03 |       - |     - |     - |         - |
