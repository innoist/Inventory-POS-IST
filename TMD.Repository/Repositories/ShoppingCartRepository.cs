using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    /// <summary>
    /// Shopping Cart Repository
    /// </summary>
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
    {
        #region Protected

        /// <summary>
        /// DbSet
        /// </summary>
        protected override IDbSet<ShoppingCart> DbSet => db.ShoppingCarts;

        #endregion


        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ShoppingCartRepository(IUnityContainer container)
            : base(container)
        {

        }

        #endregion

        #region Public

        /// <summary>
        /// Get Shopping Cart against user
        /// </summary>
        public ShoppingCart Get(string userCartId)
        {
            return DbSet.FirstOrDefault(sc => sc.UserCartId == userCartId);
        }

        #endregion
    }
}
