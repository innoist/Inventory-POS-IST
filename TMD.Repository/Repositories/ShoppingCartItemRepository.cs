using System.Data.Entity;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    /// <summary>
    /// Shopping Cart Item Repository
    /// </summary>
    public class ShoppingCartItemRepository : BaseRepository<ShoppingCartItem>, IShoppingCartItemRepository
    {

        #region Protected

        /// <summary>
        /// DbSet
        /// </summary>
        protected override IDbSet<ShoppingCartItem> DbSet => db.ShoppingCartItems;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ShoppingCartItemRepository(IUnityContainer container)
            : base(container)
        {

        }

        #endregion

    }
}
