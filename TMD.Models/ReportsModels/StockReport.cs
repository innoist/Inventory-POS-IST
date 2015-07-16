namespace TMD.Models.ReportsModels
{
    public class StockReport
    {
        public long ProductCode { get; set; }
        public string ProductName { get; set; }
        public long PurchasedQuantity { get; set; }
        public long AvailableQuantity { get; set; }

        public decimal PurchasedPrice { get; set; }
        public decimal SalePrice { get; set; }
        

    }
}
