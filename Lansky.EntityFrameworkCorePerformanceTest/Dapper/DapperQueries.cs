using Dapper;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace Lansky.EntityFrameworkCorePerformanceTest.Dapper
{
    class DapperQueries : IQueries
    {
        private SqlConnection _sqlConnection;

        public DapperQueries(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public int CountInvoices()
            => _sqlConnection.QuerySingle<int>("select count(1) from [Sales].[Invoices]");

        public IList<CustomerStockItemTuple> GetCustomerStockItemTuples(int top)
            => _sqlConnection.Query<CustomerStockItemTuple>($@"
                    select top {top} c.CustomerName, si.StockItemName
                    from [Sales].[Invoices] i
                    join [Sales].[InvoiceLines] il on i.InvoiceID = il.InvoiceID
                    join [Sales].[Customers] c on i.CustomerID = c.CustomerID
                    join [Warehouse].[StockItems] si on il.StockItemID = si.StockItemID").ToList();
    }
}
