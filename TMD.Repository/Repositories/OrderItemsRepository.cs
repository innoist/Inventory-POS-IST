using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class OrderItemsRepository: BaseRepository<OrderItem>, IOrderItemsRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public OrderItemsRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<OrderItem> DbSet
        {
            get { return db.OrderItems; }
        }
        #endregion

        public long GetItemCountInOrders(long productId)
        {
            return DbSet.Where(x => x.ProductId == productId).Select(r => r.Quantity).DefaultIfEmpty(0).Sum();
        }

        public IEnumerable<OrderItem> GetOrderItemsReport()
        {
            return DbSet.ToList();
        }
    }
}
