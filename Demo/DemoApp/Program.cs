using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NullableLogger;

namespace DemoApp
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .SetMinimumLevel(LogLevel.Trace)
                    .AddConsole(options => options.IncludeScopes = true);
            });

            // Create logger.
            var logger = loggerFactory.CreateLogger<Program>();
            using (logger.BeginScope("default logger"))
            {
                // Write trace logs in classic way.
                if (logger.IsEnabled(LogLevel.Trace))
                {
                    logger.LogTrace("Example log message in classic way");
                }

                // Write trace logs in new way with extension method. 
                logger.Trace()?.Log("Example log message in new way");
            }

            // Create wrapped logger.
            var wrappedLogger = logger.Wrap();
            using (wrappedLogger.BeginScope("wrapped logger"))
            {
                // Writing trace logs in classic way is still available.
                if (wrappedLogger.IsEnabled(LogLevel.Trace))
                {
                    wrappedLogger.LogTrace("Example log message in classic way by wrapped logger");
                }

                // Write trace logs in new way by wrapped logger. 
                wrappedLogger.Trace?.Log("Example log message in new way by wrapped logger");
            }

            await Task.Delay(1000);
            await Console.Out.WriteLineAsync("Hello World!");
        }
    }
}