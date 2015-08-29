using System;
using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface ISalesSummaryViewRepository : IBaseRepository<SalesSummaryView, long>
    {
        IEnumerable<SalesSummaryView> SalesSummaryResultByDateRange(DateTime fromDate, DateTime toDate);
    }
}
