using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class ExpenseRepository: BaseRepository<Expense>, IExpenseRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ExpenseRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Expense> DbSet
        {
            get { return db.Expenses; }
        }
        #endregion

        public IEnumerable<Expense> GetExpenses(int year, int month, string vendor)
        {
            IEnumerable<Expense> expenses = DbSet.Where(x => 
                DbFunctions.TruncateTime(x.ExpenseDate).Value.Year == year & 
                DbFunctions.TruncateTime(x.ExpenseDate).Value.Month == month &
                ((x.Vendor != null && x.Vendor.Name.Contains(vendor)) | x.Vendor == null)).ToList();
            return expenses;
        }
    }
}
