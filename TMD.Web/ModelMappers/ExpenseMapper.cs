using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class ExpenseMapper
    {
        public static Expense CreateFromClientToServer(this ExpenseModel source)
        {
            return new Expense
            {
                Id =source.Id,
                ExpenseAmount = source.ExpenseAmount,
                ExpenseCategoryId = source.ExpenseCategoryId,
                ExpenseDate = source.ExpenseDate,
                Description = source.Description,                
                
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }

        public static ExpenseModel CreateFromServerToClient(this Expense source)
        {
            return new ExpenseModel
            {
                Id = source.Id,
                ExpenseAmount = source.ExpenseAmount,
                ExpenseCategoryId = source.ExpenseCategoryId,
                ExpenseDate = source.ExpenseDate,
                Description = source.Description,

                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}