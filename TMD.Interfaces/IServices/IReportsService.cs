using System;
using System.Collections.Generic;
using TMD.Models.ReportsModels;

namespace TMD.Interfaces.IServices
{
    public interface IReportsService
    {
        IEnumerable<SalesReport> SalesReport(string productCode,DateTime startDate, DateTime endDate);
        IEnumerable<PurchaseReport> PurchaseReport(string productCode, long vendorId, DateTime startDate, DateTime endDate);
    }
}
