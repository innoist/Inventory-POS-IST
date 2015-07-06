using System;
using TMD.Models.Common;

namespace TMD.Models.RequestModels
{
    public class InventoryItemSearchRequest : GetPagedListRequest
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public long ProductCode{ get; set; }
        public int Vendor{ get; set; }
        public DateTime? PurchaseDate { get; set; }

        public InventoryItemByColumn ItemOrderBy
        {
            get
            {
                return (InventoryItemByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
