using TMD.Models.DomainModels;
using TMD.Models.ReportsModels;

namespace TMD.Models.ModelMapers.ReportsMappers
{
    public static class ExpenseReportMapper
    {
        public static ExpenseReport CreateReport(this Expense source)
        {
            return new ExpenseReport
            {
                ExpenseDate = source.ExpenseDate,
                ExpenseDesc = source.Description,
                ExpenseAmount = source.ExpenseAmount,
                VendorName = source.Vendor != null ? source.Vendor.Name : string.Empty
            };
        }
    }
}
