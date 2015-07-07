using System.Collections.Generic;

namespace TMD.Models.DomainModels
{
    public class ExpenseCategory
    {        
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
