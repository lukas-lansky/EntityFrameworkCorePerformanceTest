using BenchmarkDotNet.Running;
using Lansky.EntityFrameworkCorePerformanceTest.Dapper;
using Lansky.EntityFrameworkCorePerformanceTest.EfCore;
using System;

namespace Lansky.EntityFrameworkCorePerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<DapperBenchmark>();
            BenchmarkRunner.Run<EfCoreBenchmark>();
            Console.ReadLine();
        }
    }
}
