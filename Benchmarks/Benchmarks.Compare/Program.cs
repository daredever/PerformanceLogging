using BenchmarkDotNet.Running;

namespace Benchmarks.Compare
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<TraceLogging>();
            BenchmarkRunner.Run<TraceLoggingWithFormat>();
        }
    }
}