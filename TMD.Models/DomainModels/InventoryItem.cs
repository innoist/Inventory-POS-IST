namespace TMD.Models.DomainModels
{
    public class InventoryItem
    {
        public long ItemId { get; set; }
        public long ProductId { get; set; }
        public long VendorId { get; set; }
        public long Quantity { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string Comments { get; set; }
        public System.DateTime PurchasingDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MinSalePriceAllowed { get; set; }

        public virtual Product Product { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
