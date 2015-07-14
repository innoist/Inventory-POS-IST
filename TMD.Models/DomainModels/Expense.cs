namespace TMD.Models.DomainModels
{
    public class Expense
    {
        public long Id { get; set; }        
        public System.DateTime ExpenseDate { get; set; }
        public long ExpenseCategoryId { get; set; }
        public decimal ExpenseAmount { get; set; }
        public string Description { get; set; }
        public long? VendorId { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        public virtual ExpenseCategory ExpenseCategory { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
