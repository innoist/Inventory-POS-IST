using System;

namespace TMD.Models.DomainModels
{
    public class SalesSummaryView
    {
        public long RowNo { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal? GrossSale { get; set; }
        public int? Discount { get; set; }
        public decimal? ItemsCost { get; set; }
        public decimal? NetSale { get; set; }
        public decimal? Profit { get; set; }
        public decimal? ProfitPercentage { get; set; }
    }
}
