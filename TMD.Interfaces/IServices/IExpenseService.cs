using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IExpenseService
    {
        Expense GetExpense(long expenseCategoryId);
        IEnumerable<Expense> GetAllExpenses();
        long AddExpense(Expense expense);
    }
}
