using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class InventoryItemMapper
    {
        public static InventoryItem CreateFromClientToServer(this InventoryItemModel source)
        {
            return new InventoryItem
            {
                ItemId = source.ItemId,
                ProductId = source.ProductId,
                Quantity = source.Quantity,
                VendorId = source.VendorId,
                Comments = source.Comments,
                MinSalePriceAllowed = source.MinSalePriceAllowed,
                PurchasePrice = source.PurchasePrice,
                SalePrice = source.SalePrice,
                PurchasingDate = source.PurchasingDate,

                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }

        public static InventoryItemModel CreateFromServerToClient(this InventoryItem source)
        {
            return new InventoryItemModel
            {
                ItemId = source.ItemId,
                ProductId = source.ProductId,
                Quantity = source.Quantity,
                VendorId = source.VendorId,
                Comments = source.Comments,
                MinSalePriceAllowed = source.MinSalePriceAllowed,
                PurchasePrice = source.PurchasePrice,
                SalePrice = source.SalePrice,
                PurchasingDate = source.PurchasingDate,

                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }

        public static InventoryItemListModel CreateListServerToClient(this InventoryItem source)
        {
            return new InventoryItemListModel
            {
                ItemId = source.ItemId,
                ProductId = source.ProductId,
                ProductName = source.Product.Name,
                Quantity = source.Quantity,
                VendorId = source.VendorId,
                VendorName = source.Vendor.Name,
                PurchasePrice = source.PurchasePrice,
                SalePrice = source.SalePrice,
                PurchasingDate = source.PurchasingDate.ToShortDateString()
            };
        }
    }
}