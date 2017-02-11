using System.Data.SqlClient;

namespace Lansky.EntityFrameworkCorePerformanceTest.Dapper
{
    public class DapperBenchmark : TheBenchmark
    {
        public DapperBenchmark() : base(new DapperQueries(new SqlConnection("Data Source=.;Integrated Security=True;Initial Catalog=WideWorldImporters")))
        {
        }
    }
}
