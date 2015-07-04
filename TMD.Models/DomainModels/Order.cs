using System.Collections.Generic;

namespace TMD.Models.DomainModels
{
    public class Order
    {
        public long OrderId { get; set; }
        public bool IsModified { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string Comments { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
