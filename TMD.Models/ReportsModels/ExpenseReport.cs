using System;

namespace TMD.Models.ReportsModels
{
    public class ExpenseReport
    {
        public DateTime ExpenseDate { get; set; }
        public string VendorName { get; set; }
        public decimal ExpenseAmount { get; set; }
    }
}
