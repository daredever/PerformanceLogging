using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace Benchmarks.Common.Logging
{
    public class LoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, Logger> _loggers =
            new ConcurrentDictionary<string, Logger>();

        public ILogger CreateLogger(string categoryName) =>
            _loggers.GetOrAdd(categoryName, name => new Logger());

        public void Dispose() => _loggers.Clear();
    }
}