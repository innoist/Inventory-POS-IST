using System;

namespace TMD.Models.ReportsModels
{
    public class SalesReport
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public long ProductCode { get; set; }
        public long Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public decimal SubTotalSale { get; set; }
        public long Discount { get; set; }
        public decimal TotalSale { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalProfit { get; set; }
        public decimal ProfitPercentage { get; set; }
    }
}
