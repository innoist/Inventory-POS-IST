using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IExpenseCategoryService
    {
        ExpenseCategory GetExpenseCategory(long expenseCategoryId);
        IEnumerable<ExpenseCategory> GetAllExpenseCategories();
        long AddExpenseCategory(ExpenseCategory expenseCategory);
    }
}
