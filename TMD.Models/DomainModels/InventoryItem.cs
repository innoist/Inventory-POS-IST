namespace TMD.Models.DomainModels
{
    public class InventoryItem
    {
        public long ItemId { get; set; }
        public long ProductId { get; set; }
        public int VendorId { get; set; }
        public long Quantity { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
