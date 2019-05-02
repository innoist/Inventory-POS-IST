using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    /// <summary>
    /// Shopping Cart Item Repository Interface
    /// </summary>
    public interface IShoppingCartItemRepository : IBaseRepository<ShoppingCartItem, long>
    {
    }
}
