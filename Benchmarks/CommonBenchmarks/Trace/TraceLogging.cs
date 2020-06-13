using BenchmarkDotNet.Attributes;
using CommonBenchmarks.Logging;
using Microsoft.Extensions.Logging;
using PerformanceLogging;

namespace CommonBenchmarks.Trace
{
    /// <summary>
    /// Benchmarks for comparing classic and new way logging with specified log message.
    /// </summary>
    [MemoryDiagnoser]
    public class TraceLogging
    {
        private ILogger<TraceLogging> _logger;
        private IPerformanceLogger _wrappedLogger;

        /// <summary>
        /// Total count of writing log messages. 
        /// </summary>
        [Params(1, 10, 100, 1000)]
        public int LogLinesCount { get; set; }

        /// <summary>
        /// Current minimum log level.
        /// </summary>
        [Params(LogLevel.Trace, LogLevel.Debug)]
        public LogLevel MinimumLogLevel { get; set; }

        /// <summary>
        /// Configure logger factory and create loggers.
        /// </summary>
        [GlobalSetup]
        public void GlobalSetup()
        {
            // Configure logger factory.
            var loggerFactory = LoggerFactory.Create(builder => builder.SetMinimumLevel(MinimumLogLevel));
            loggerFactory.AddLogger();

            // Create logger.
            _logger = loggerFactory.CreateLogger<TraceLogging>();
            _wrappedLogger = _logger.Wrap();
        }

        /// <summary>
        /// Writes logs in classic way using default logger's LogTrace() extension.
        /// </summary>
        [Benchmark(Baseline = true, Description = "logger.LogTrace()")]
        public void ClassicWayLog()
        {
            for (var i = 0; i < LogLinesCount; i++)
            {
                _logger.LogTrace($"Log line #{i}.");
            }
        }

        /// <summary>
        /// Checks if <see cref="LogLevel.Trace"/> is enabled and writes logs in classic way
        /// with using default logger's LogTrace() extension.
        /// </summary>
        [Benchmark(Description = "if(TraceEnabled){logger.LogTrace()}")]
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

        /// <summary>
        /// Writes logs in new way using PerformanceLogging's Trace() extension.
        /// </summary>
        [Benchmark(Description = "logger.Trace()?.Log()")]
        public void NewWayLogExtension()
        {
            for (var i = 0; i < LogLinesCount; i++)
            {
                _logger.Trace()?.Log($"Log line #{i}.");
            }
        }

        /// <summary>
        /// Writes logs in new way using PerformanceLogging's wrapper for default logger.
        /// </summary>
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