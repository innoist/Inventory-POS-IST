using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;

namespace TMD.Interfaces.IServices
{
    /// <summary>
    /// Shopping Cart Service Interface
    /// </summary>
    public interface IShoppingCartService
    {
        /// <summary>
        /// Get Shopping Cart against id
        /// </summary>
        ShoppingCart Get(long id);

        /// <summary>
        /// Get Shopping Cart for user
        /// </summary>
        ShoppingCart Get(string userCartId);
        
        // Add multiple item to user cart
        bool AddShoppingCart(IEnumerable<ShoppingCart> cart);
        // Add single item to user cart
        bool AddItemToCart(ShoppingCart cart);
        // Sync cart
        bool SyncShoppingCart(ShoppingCartSearchRequest request);
        bool UpdateShoppingCart(ShoppingCart cart);
        void DeleteShoppingCart(long cartId);
    }
}
