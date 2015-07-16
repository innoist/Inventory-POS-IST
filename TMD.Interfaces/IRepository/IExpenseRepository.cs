using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IExpenseRepository : IBaseRepository<Expense, long>
    {
        IEnumerable<Expense> GetExpenses(int year, int month, string vendor);
    }
}
