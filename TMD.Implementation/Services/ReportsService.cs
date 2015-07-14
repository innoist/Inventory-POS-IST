using System;
using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.ModelMapers.ReportsMappers;
using TMD.Models.ReportsModels;

namespace TMD.Implementation.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IOrderItemsRepository orderItemsRepository;
        private readonly IInventoryItemRepositoy inventoryItemRepositoy;

        public ReportsService(IOrderItemsRepository orderItemsRepository,IInventoryItemRepositoy inventoryItemRepositoy)
        {
            this.orderItemsRepository = orderItemsRepository;
            this.inventoryItemRepositoy = inventoryItemRepositoy;
        }

        public IEnumerable<SalesReport> SalesReport(string productCode,DateTime startDate, DateTime endDate)
        {
            var report = orderItemsRepository.GetOrderItemsReport(productCode,startDate,endDate).ToList().Select(x => x.CreateReport());
            return report;
        }

        public IEnumerable<PurchaseReport> PurchaseReport(string productCode, long vendorId, DateTime startDate, DateTime endDate)
        {
            var report = inventoryItemRepositoy.PurchaseReport(productCode, vendorId, startDate, endDate).ToList().Select(x => x.CreateReport());
            return report;
        }
    }
}
