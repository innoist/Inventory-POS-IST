namespace TMD.Models.DomainModels
{
    public class OrderItem
    {
        public long OrderItemId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public long OrderId { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal AmountGiven { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MinSalePriceAllowed { get; set; }
        public byte Discount { get; set; }
        public string Comments { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
