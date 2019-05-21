using System.Collections.Generic;

namespace TMD.Models.DomainModels
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; } 
        
        
    }
}
