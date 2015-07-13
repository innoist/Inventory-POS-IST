using TMD.Models.Common;

namespace TMD.Models.RequestModels
{
    public class ProductSearchRequest : GetPagedListRequest
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public long ProductCode{ get; set; }
        public long Category { get; set; }
        public decimal PurchasePrice { get; set; }

        public ProductByColumn ProductOrderBy
        {
            get
            {
                return (ProductByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }

        public ProductSearchRequest()
        {
            SortBy = 0;
            IsAsc = false;
        }

    }
}
