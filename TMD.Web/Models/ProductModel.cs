namespace TMD.Web.Models
{
    public class ProductModel
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
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
    }
}