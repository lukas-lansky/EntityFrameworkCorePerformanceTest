using BenchmarkDotNet.Running;
using System;

namespace Lansky.EntityFrameworkCorePerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<DapperBenchmark>();
            Console.ReadLine();
        }
    }
}
