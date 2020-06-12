using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using NullableLogger.Benchmarks.Logger;

namespace NullableLogger.Benchmarks
{
    [MemoryDiagnoser]
    public class TraceLogging
    {
        private ILogger<TraceLogging> _logger;
        private INullableLogger _wrappedLogger;

        [Params(10, 100, 1000)]
        public int LogLinesCount { get; set; }

        [Params(LogLevel.Trace, LogLevel.Debug)]
        public LogLevel LogLevel { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.SetMinimumLevel(LogLevel));
            loggerFactory.AddCustomLogger(LogLevel);

            // Create logger.
            _logger = loggerFactory.CreateLogger<TraceLogging>();
            _wrappedLogger = _logger.Wrap();
        }

        [Benchmark(Baseline = true, Description = "logger.LogTrace()")]
        public void ClassicWayLog()
        {
            for (var i = 0; i < LogLinesCount; i++)
            {
                _logger.LogTrace($"Log line #{i}.");
            }
        }

        [Benchmark(Description = "if (isEnabled) { logger.LogTrace() }")]
        public void ClassicWayLogWithCheck()
        {
            for (var i = 0; i < LogLinesCount; i++)
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                {
                    _logger.LogTrace($"Log line #{i}.");
                }
            }
        }

        [Benchmark(Description = "logger.Trace()?.Log()")]
        public void NewWayLogExtension()
        {
            for (var i = 0; i < LogLinesCount; i++)
            {
                _logger.Trace()?.Log($"Log line #{i}.");
            }
        }

        [Benchmark(Description = "wrappedLogger.Trace?.Log()")]
        public void NewWayLogWrapped()
        {
            for (var i = 0; i < LogLinesCount; i++)
            {
                _wrappedLogger.Trace?.Log($"Log line #{i}.");
            }
        }
    }
}