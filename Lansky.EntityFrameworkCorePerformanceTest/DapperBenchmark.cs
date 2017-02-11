using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using Lansky.EntityFrameworkCorePerformanceTest.Dapper;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Lansky.EntityFrameworkCorePerformanceTest
{
    public class DapperBenchmark
    {
        private readonly DapperQueries _dapperQueries;

        public DapperBenchmark()
        {
            _dapperQueries = new DapperQueries(new SqlConnection("Data Source=.;Integrated Security=True;Initial Catalog=WideWorldImporters"));
        }

        [Benchmark]
        public void CountInvoices()
        {
            var count = _dapperQueries.CountInvoices();
            Debug.Assert(count == 67302);
        }

        [Benchmark]
        public void GetFirst100CustomerStockItemTuples()
        {
            var tuples = _dapperQueries.GetCustomerStockItemTuples(100);
            Debug.Assert(tuples.Count == 100);
            Debug.Assert(tuples[0].CustomerName == "Wingtip Toys (Obetz, OH)");
            Debug.Assert(tuples[1].StockItemName == "Developer joke mug - old C developers never die (White)");
        }

        [Benchmark]
        public void GetFirst1000CustomerStockItemTuples()
        {
            var tuples = _dapperQueries.GetCustomerStockItemTuples(1000);
            Debug.Assert(tuples.Count == 1000);
            Debug.Assert(tuples[0].CustomerName == "Wingtip Toys (Obetz, OH)");
            Debug.Assert(tuples[1].StockItemName == "Developer joke mug - old C developers never die (White)");
        }

        [Benchmark]
        public void GetFirst10000CustomerStockItemTuples()
        {
            var tuples = _dapperQueries.GetCustomerStockItemTuples(10000);
            Debug.Assert(tuples.Count == 10000);
            Debug.Assert(tuples[0].CustomerName == "Wingtip Toys (Obetz, OH)");
            Debug.Assert(tuples[1].StockItemName == "Developer joke mug - old C developers never die (White)");
        }
    }

    public class DapperBenchmarkConfiguration : ManualConfig
    {
        public DapperBenchmarkConfiguration()
        {
            Add(new Job(EnvMode.RyuJitX64, EnvMode.LegacyJitX64) {
                    Env = { Runtime = Runtime.Clr }
            });
        }
    }
}
