using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using NullableLogger.Benchmarks.Logger;

namespace NullableLogger.Benchmarks
{
    [MemoryDiagnoser]
    public class TraceLogging
    {
        private readonly ILogger<TraceLogging> _logger;
        private readonly INullableLogger _wrappedLogger;
        private const int Length = 100;

        public TraceLogging()
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.SetMinimumLevel(LogLevel.Trace));
            loggerFactory.AddCustomLogger(LogLevel.Debug);

            // Create logger.
            _logger = loggerFactory.CreateLogger<TraceLogging>();
            _wrappedLogger = _logger.Wrap();
        }

        [Benchmark]
        public void ClassicWayLog()
        {
            for (var i = 0; i < Length; i++)
            {
                _logger.LogTrace($"Log line #{i}.");
            }
        }

        [Benchmark]
        public void ClassicWayLogWithCheck()
        {
            for (var i = 0; i < Length; i++)
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                {
                    _logger.LogTrace($"Log line #{i}.");
                }
            }
        }

        [Benchmark]
        public void NewWayLogExtension()
        {
            for (var i = 0; i < Length; i++)
            {
                _logger.Trace()?.Log($"Log line #{i}.");
            }
        }

        [Benchmark]
        public void NewWayLogWrap()
        {
            var wrappedLogger = _logger.Wrap();
            for (var i = 0; i < Length; i++)
            {
                wrappedLogger.Trace?.Log($"Log line #{i}.");
            }
        }

        [Benchmark]
        public void NewWayLogWrapOnce()
        {
            for (var i = 0; i < Length; i++)
            {
                _wrappedLogger.Trace?.Log($"Log line #{i}.");
            }
        }
    }
}