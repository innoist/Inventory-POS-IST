using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Models.DomainModels
{
    public class ProductsStock
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public long? PurchasedQty { get; set; }
        public int? SoldQty { get; set; }
        public long AvailableQty { get; set; }
    }
}
