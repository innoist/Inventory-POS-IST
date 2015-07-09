using System.Data.Entity;
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
    }
}
