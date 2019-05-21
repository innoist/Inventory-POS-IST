using System;
using TMD.Models.Common;

namespace TMD.Models.RequestModels
{
    public class OrderSearchRequest : GetPagedListRequest
    {
        public string  OrderId { get; set; }
        public DateTime ? OrderDate { get; set; }
        public string  ProductCode { get; set; }
        public int IsOnline { get; set; }
        public int? IsOpen { get; set; }
        public long? CustomerId { get; set; }


        public OrdersByColumn OrdersOrderBy
        {
            get
            {
                return (OrdersByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
        public OrderSearchRequest()
        {
            SortBy = 0;
            IsAsc = false;
        }

    }
}
