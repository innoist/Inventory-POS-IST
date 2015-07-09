using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IExpenseRepository : IBaseRepository<Expense, long>
    {        
    }
}
