using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TMD.Models.DomainModels;

namespace TMD.Web.Models
{
    public class OrderModel
    {
        public OrderModel()
        {
            Customer = new CustomerModel();
        }
        public long OrderId { get; set; }
        public long ? CustomerId { get; set; }
        public bool IsModified { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsOpen { get; set; }
        public bool IsOnline { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string Comments { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        public List<OrderItemModel> OrderItems { get; set; }
        public CustomerModel  Customer { get; set; }


        public int AllowedMaxDiscount { get; set; }

        //public virtual Customer Customer { get; set; }
    }
}