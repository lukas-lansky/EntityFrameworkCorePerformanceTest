﻿using System.Collections.Generic;

namespace Lansky.EntityFrameworkCorePerformanceTest
{
    interface IQueries
    {
        int CountInvoices();

        IList<CustomerStockItemTuple> GetCustomerStockItemTuples(int top);
    }

    public struct CustomerStockItemTuple
    {
        public string CustomerName;

        public string StockItemName;
    }
}
