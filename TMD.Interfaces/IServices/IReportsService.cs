using System.Collections.Generic;
using TMD.Models.ReportsModels;

namespace TMD.Interfaces.IServices
{
    public interface IReportsService
    {
        IEnumerable<SalesReport> SalesReport();
    }
}
