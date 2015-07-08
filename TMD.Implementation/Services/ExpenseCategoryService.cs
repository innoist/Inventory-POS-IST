using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly IExpenseCategoryRepository expenseCategoryRepository;

        public ExpenseCategoryService(IExpenseCategoryRepository expenseCategoryRepository)
        {
            this.expenseCategoryRepository = expenseCategoryRepository;
        }

        public ExpenseCategory GetExpenseCategory(long expenseCategoryId)
        {
            return expenseCategoryRepository.Find(expenseCategoryId);
        }

        public IEnumerable<ExpenseCategory> GetAllExpenseCategories()
        {
            return expenseCategoryRepository.GetAll();
        }

        public long AddExpenseCategory(ExpenseCategory expenseCategory)
        {
            if (expenseCategory.Id > 0)
                expenseCategoryRepository.Update(expenseCategory);
            else
                expenseCategoryRepository.Add(expenseCategory);

            expenseCategoryRepository.SaveChanges();
            return expenseCategory.Id;
        }
    }
}

