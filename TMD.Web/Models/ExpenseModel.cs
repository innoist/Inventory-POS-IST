namespace TMD.Web.Models
{
    public class ExpenseModel
    {
        public long Id { get; set; }
        public System.DateTime ExpenseDate { get; set; }
        public long ExpenseCategoryId { get; set; }
        public decimal ExpenseAmount { get; set; }
        public string Description { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
    }
}