using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    /// <summary>
    /// Shopping Cart Repository Interface
    /// </summary>
    public interface IShoppingCartRepository : IBaseRepository<ShoppingCart, long>
    {
        /// <summary>
        /// Get Shopping Cart against user
        /// </summary>
        ShoppingCart Get(string userCartId);
    }
}
