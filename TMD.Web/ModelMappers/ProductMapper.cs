using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class ProductMapper
    {
        public static Product CreateFromClientToServer(this ProductModel source)
        {
            return new Product
            {
                CategoryId = source.CategoryId,
                ProductId = source.ProductId,
                VendorId = source.VendorId,
                ProductBarCode = source.ProductBarCode,
                ProductCode = source.ProductCode,
                Name = source.Name,
                PurchasePrice = source.PurchasePrice,
                SalePrice = source.SalePrice,
                MinSalePriceAllowed = source.MinSalePriceAllowed,
                Comments = source.Comments,

                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }

        public static ProductModel CreateFromServerToClient(this Product source)
        {
            return new ProductModel
            {
                CategoryId = source.CategoryId,
                ProductId = source.ProductId,
                VendorId = source.VendorId,
                ProductBarCode = source.ProductBarCode,
                ProductCode = source.ProductCode,
                Name = source.Name,
                PurchasePrice = source.PurchasePrice,
                SalePrice = source.SalePrice,
                MinSalePriceAllowed = source.MinSalePriceAllowed,

                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}