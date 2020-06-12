using BenchmarkDotNet.Running;

namespace NullableLogger.Benchmarks
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<TraceLogging>();
        }
    }
}