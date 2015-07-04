using System.Data.Entity;
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
    }
}
