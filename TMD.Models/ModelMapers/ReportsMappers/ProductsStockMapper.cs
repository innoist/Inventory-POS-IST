using TMD.Models.DomainModels;
using TMD.Models.ReportsModels;

namespace TMD.Models.ModelMapers.ReportsMappers
{
    public static class ProductsStockMapper
    {
        public static StockReport CreateReport(this ProductsStock source)
        {
            return new StockReport
            {
               ProductCode = source.ProductId,
               ProductName = source.Name,
               AvailableQuantity = source.AvailableQty,
               PurchasedQuantity = source.PurchasedQty ?? 0
            };
        }       
    }
}