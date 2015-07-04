using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TMD.Web.Models
{
    public class OrderModel
    {
        public long OrderId { get; set; }
        public long CustomerId { get; set; }
        public bool IsModified { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string Comments { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        public List<OrderItemModel> OrderItems { get; set; }
        //public virtual Customer Customer { get; set; }
    }
}