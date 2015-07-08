using System;
using TMD.Models.Common;

namespace TMD.Models.RequestModels
{
    public class OrderSearchRequest : GetPagedListRequest
    {
        public long  OrderId { get; set; }
        public DateTime ? OrderDate { get; set; }
        public long  ProductCode { get; set; }


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
    }
}
