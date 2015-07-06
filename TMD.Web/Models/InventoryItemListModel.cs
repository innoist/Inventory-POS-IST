namespace TMD.Web.Models
{
    public class InventoryItemListModel
    {
        public long ItemId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public long VendorId { get; set; }
        public string VendorName { get; set; }
        public long Quantity { get; set; }
        public string PurchasingDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
    }
}