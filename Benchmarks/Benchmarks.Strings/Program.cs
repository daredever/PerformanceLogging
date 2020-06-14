using BenchmarkDotNet.Running;

namespace Benchmarks.Strings
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<TraceLogging>();
        }
    }
}