using System;
using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class SalesSummaryViewService:ISalesSummaryViewService
    {
        private readonly ISalesSummaryViewRepository salesSummaryViewRepository;

        public SalesSummaryViewService(ISalesSummaryViewRepository salesSummaryViewRepository)
        {
            this.salesSummaryViewRepository = salesSummaryViewRepository;
        }

        public IEnumerable<SalesSummaryView> GetAllSalesFromStartToEnd()
        {
            return salesSummaryViewRepository.GetAll();
        }

        public IEnumerable<SalesSummaryView> SalesSummaryResultByDateRange(DateTime fromDate, DateTime toDate)
        {
            return salesSummaryViewRepository.SalesSummaryResultByDateRange(fromDate,toDate);
        }
    }
}
