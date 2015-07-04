namespace TMD.Web.Models
{
    public class InventoryItemModel
    {
        public long ItemId { get; set; }
        public long ProductId { get; set; }
        public int VendorId { get; set; }
        public long Quantity { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
    }
}