using System.Collections.Generic;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class ExpenseViewModel
    {
        public ExpenseViewModel()
        {
            ExpenseCategories = new List<ExpenseCategoryModel>();
        }
        public ExpenseModel ExpenseModel { get; set; }
        public IEnumerable<ExpenseCategoryModel> ExpenseCategories { get; set; }
        public IEnumerable<VendorModel> Vendors { get; set; }
    }
}