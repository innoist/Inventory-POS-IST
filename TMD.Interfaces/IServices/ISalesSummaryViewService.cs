using System;
using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface ISalesSummaryViewService
    {
        IEnumerable<SalesSummaryView> GetAllSalesFromStartToEnd();
        IEnumerable<SalesSummaryView> SalesSummaryResultByDateRange(DateTime fromDate, DateTime toDate);
    }
}
