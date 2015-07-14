using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IProductsStockRepository : IBaseRepository<ProductsStock, long>
    {
        IEnumerable<ProductsStock> StocksReport(string barCode, string productCode, string productName);
    }
}
