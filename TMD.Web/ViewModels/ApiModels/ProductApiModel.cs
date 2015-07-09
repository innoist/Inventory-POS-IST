namespace TMD.Web.ViewModels.ApiModels
{
    public class ProductApiModel
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
        public long AvailableItems { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public string RecCreatedBy { get; set; }
    }
}