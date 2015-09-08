using System;
using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.ReportsModels;

namespace TMD.Interfaces.IServices
{
    public interface IReportsService
    {
        IEnumerable<SalesReport> SalesReport(string productCode,DateTime startDate, DateTime endDate);
        IEnumerable<SalesReport> SalesSummaryReport(DateTime startDate, DateTime endDate);
        IEnumerable<PurchaseReport> PurchaseReport(string productCode, long vendorId, DateTime startDate, DateTime endDate);
        IEnumerable<StockReport> StocksReport(string barCode, string productCode, string productName);
        IEnumerable<ExpenseReport> ExpensesReport(int year, int month, string vendor);


        IEnumerable<SalesSummaryView> GetAllSalesFromStartToEnd();
        IEnumerable<SalesSummaryView> SalesSummaryResultByDateRange(DateTime fromDate, DateTime toDate);
    }
}
