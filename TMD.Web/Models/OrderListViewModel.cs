using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TMD.Models.DomainModels;

namespace TMD.Web.Models
{
    public class OrderListViewModel
    {
        public string OrderId { get; set; }
        public long ? CustomerId { get; set; }
        public bool IsModified { get; set; }
        public string RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string Comments { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        public double TotalSale { get; set; }
        public double TotalItems { get; set; }

        public double TotalDiscount { get; set; }

        public string CustomerPhone { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        
        //Will only use at printing
        public List<OrderItemModel> OrderItems { get; set; }
        //public virtual Customer Customer { get; set; }
    }
}