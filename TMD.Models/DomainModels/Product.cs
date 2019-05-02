using System.Collections.Generic;

namespace TMD.Models.DomainModels
{
    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public string Comments { get; set; }
        public string ProductBarCode { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MinSalePriceAllowed { get; set; }
        public long CategoryId { get; set; }
        public long VendorId { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public string Specification { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
