using Lansky.EntityFrameworkCorePerformanceTest.EfCore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Lansky.EntityFrameworkCorePerformanceTest.EfCore
{
    public class EfCoreQueries : IQueries
    {
        private readonly WideWorldImportersContext _dbContext;

        public EfCoreQueries(bool tracking)
        {
            _dbContext = new WideWorldImportersContext() { UseTracking = tracking };
        }

        public int CountInvoices()
            => _dbContext.Invoices.Count();

        public IList<CustomerStockItemTuple> GetCustomerStockItemTuples(int top)
            => _dbContext.Invoices
                .Join(_dbContext.InvoiceLines, invoice => invoice.InvoiceId, invoiceLine => invoiceLine.InvoiceLineId, (invoice, invoiceLine) => new { invoice.CustomerId, invoiceLine.StockItemId, invoice.InvoiceId })
                .Join(_dbContext.Customers, prevJoin => prevJoin.CustomerId, customer => customer.CustomerId, (prevJoin, customer) => new { prevJoin.StockItemId, customer.CustomerName, prevJoin.InvoiceId })
                .Join(_dbContext.StockItems, prevJoin => prevJoin.StockItemId, stockItem => stockItem.StockItemId, (prevJoin, stockItem) => new { stockItem.StockItemName, prevJoin.CustomerName, prevJoin.InvoiceId })
                .OrderBy(t => t.InvoiceId)
                .Take(top)
                .ToList()
                .Select(t => new CustomerStockItemTuple { CustomerName = t.CustomerName, StockItemName = t.StockItemName })
                .ToList();
    }
}
