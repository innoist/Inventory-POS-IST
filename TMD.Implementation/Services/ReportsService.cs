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

        public ReportsService(IOrderItemsRepository orderItemsRepository)
        {
            this.orderItemsRepository = orderItemsRepository;
        }

        public IEnumerable<SalesReport> SalesReport()
        {
            var report = orderItemsRepository.GetOrderItemsReport().ToList();
            return report.Select(x=>x.CreateReport());
        }
    }
}
