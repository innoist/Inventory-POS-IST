using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Models.RequestModels
{
    /// <summary>
    /// Shopping Cart Request Model
    /// </summary>
    public class ShoppingCartSearchRequest
    {
        public string UserCartId { get; set; }
        public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
