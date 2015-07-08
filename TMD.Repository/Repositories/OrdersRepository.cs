using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.Common;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class OrdersRepository: BaseRepository<Order>, IOrdersRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public OrdersRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Order> DbSet
        {
            get { return db.Orders; }
        }

        readonly Dictionary<OrdersByColumn, Func<Order, object>> requestClause =
          new Dictionary<OrdersByColumn, Func<Order, object>>
                {
                    {OrdersByColumn.OrderId, c => c.OrderId},
                    {OrdersByColumn.OrderDate, c => c.RecCreatedDate}
                    
                };
        #endregion

        public Models.ResponseModels.OrderSearchResponse GetOrdersSearchResponse(Models.RequestModels.OrderSearchRequest searchRequest)
        {
            int fromRow = (searchRequest.PageNo - 1) * searchRequest.PageSize;
            int toRow = searchRequest.PageSize;
            Expression<Func<Order, bool>> query =
                    s => (
                            (
                             (string.IsNullOrEmpty( searchRequest.OrderId )|| s.OrderId.ToString().Equals(searchRequest.OrderId)) &&
                            (string.IsNullOrEmpty(searchRequest.ProductCode) || s.OrderItems.Where(x=>x.ProductId.ToString()==searchRequest.ProductCode).Any())
                            && (searchRequest.OrderDate == null || EntityFunctions.TruncateTime(s.RecCreatedDate) == searchRequest.OrderDate.Value)
                            )
                        );
            IEnumerable<Order> result =
                searchRequest.IsAsc
                    ? DbSet.Where(query)
                        .OrderBy(requestClause[searchRequest.OrdersOrderBy])
                        .Skip(fromRow)
                        .Take(toRow)
                        .ToList()
                    : DbSet.Where(query)
                        .OrderByDescending(requestClause[searchRequest.OrdersOrderBy])
                        .Skip(fromRow)
                        .Take(toRow)
                        .ToList();

            return new OrderSearchResponse { Orders = result, TotalCount = DbSet.Count(), FilteredCount = DbSet.Count(query) };

        }
    }
}
