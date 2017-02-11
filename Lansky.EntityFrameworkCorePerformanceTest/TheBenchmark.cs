using BenchmarkDotNet.Attributes;
using System.Diagnostics;

namespace Lansky.EntityFrameworkCorePerformanceTest
{
    [Config(typeof(BenchmarkConfiguration))]
    public abstract class TheBenchmark
    {
        protected readonly IQueries _queries;
        
        public TheBenchmark(IQueries queries)
        {
            _queries = queries;
        }

        [Benchmark]
        public void CountInvoices()
        {
            var count = _queries.CountInvoices();
            Debug.Assert(count == 67302);
        }

        [Benchmark]
        public void GetFirst100CustomerStockItemTuples()
        {
            var tuples = _queries.GetCustomerStockItemTuples(100);
            Debug.Assert(tuples.Count == 100);
            Debug.Assert(tuples[0].CustomerName == "Wingtip Toys (Obetz, OH)");
            Debug.Assert(tuples[1].StockItemName == "Developer joke mug - old C developers never die (White)");
        }

        [Benchmark]
        public void GetFirst1000CustomerStockItemTuples()
        {
            var tuples = _queries.GetCustomerStockItemTuples(1000);
            Debug.Assert(tuples.Count == 1000);
            Debug.Assert(tuples[0].CustomerName == "Wingtip Toys (Obetz, OH)");
            Debug.Assert(tuples[1].StockItemName == "Developer joke mug - old C developers never die (White)");
        }

        [Benchmark]
        public void GetFirst10000CustomerStockItemTuples()
        {
            var tuples = _queries.GetCustomerStockItemTuples(10000);
            Debug.Assert(tuples.Count == 10000);
            Debug.Assert(tuples[0].CustomerName == "Wingtip Toys (Obetz, OH)");
            Debug.Assert(tuples[1].StockItemName == "Developer joke mug - old C developers never die (White)");
        }
    }
}
