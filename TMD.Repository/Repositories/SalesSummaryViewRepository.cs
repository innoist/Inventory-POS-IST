using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class SalesSummaryViewRepository: BaseRepository<SalesSummaryView>, ISalesSummaryViewRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SalesSummaryViewRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<SalesSummaryView> DbSet
        {
            get { return db.SalesSummaryView; }
        }
        #endregion

        public IEnumerable<SalesSummaryView> SalesSummaryResultByDateRange(DateTime fromDate, DateTime toDate)
        {
            return
                DbSet.Where(
                    x =>
                        DbFunctions.TruncateTime(x.SaleDate) >= DbFunctions.TruncateTime(fromDate) &&
                        DbFunctions.TruncateTime(x.SaleDate) <= DbFunctions.TruncateTime(toDate));
        }
    }
}
