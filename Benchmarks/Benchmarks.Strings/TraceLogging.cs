using BenchmarkDotNet.Attributes;
using Benchmarks.Common.Logging;
using Microsoft.Extensions.Logging;
using PerformanceLogging;

namespace Benchmarks.Strings
{
    /// <summary>
    /// Benchmarks for comparing classic and new way logging with specified log message.
    /// </summary>
    [MemoryDiagnoser]
    public class TraceLogging
    {
        private ILogger<TraceLogging> _logger;

        /// <summary>
        /// Total count of writing log messages. 
        /// </summary>
        [Params(10, 100, 1000)]
        public int LogLinesCount { get; set; }

        /// <summary>
        /// Total count of log message. 
        /// </summary>
        [Params(1, 10, 50, 100, 200, 500)]
        public int MessageCharsCount { get; set; }

        /// <summary>
        /// Configure logger factory and create loggers.
        /// </summary>
        [GlobalSetup]
        public void GlobalSetup()
        {
            // Configure logger factory.
            var loggerFactory = LoggerFactory.Create(builder => builder.SetMinimumLevel(LogLevel.Debug));
            loggerFactory.AddLogger();

            // Create logger.
            _logger = loggerFactory.CreateLogger<TraceLogging>();
        }

        /// <summary>
        /// Writes logs in classic way using default logger's LogTrace() extension.
        /// </summary>
        [Benchmark(Baseline = true, Description = "logger.LogTrace()")]
        public void ClassicWayLog()
        {
            for (var i = 0; i < LogLinesCount; i++)
            {
                _logger.LogTrace(new string('a', MessageCharsCount));
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
                _logger.Trace()?.Log(new string('a', MessageCharsCount));
            }
        }
    }
}