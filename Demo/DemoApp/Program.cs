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
					.AddConsole();
			});

			var logger = loggerFactory.CreateLogger<Program>().Wrap();

			// classic way
			logger.LogInformation("Example log message in classic way");

			// new way 
			logger.Info?.Log("Example log message in new way");

			await Task.Delay(1000);
			await Console.Out.WriteLineAsync("Hello World!");
		}
	}
}