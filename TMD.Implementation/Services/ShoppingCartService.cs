using System;
using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;

namespace TMD.Implementation.Services
{
    /// <summary>
    /// Shopping Cart Service
    /// </summary>
    public class ShoppingCartService : IShoppingCartService
    {
        #region Private

        private readonly IShoppingCartRepository repository;
        private readonly IShoppingCartItemRepository itemRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ShoppingCartService(IShoppingCartRepository repository, IShoppingCartItemRepository itemRepository)
        {
            this.repository = repository;
            this.itemRepository = itemRepository;
        }

        #endregion

        #region Public

        /// <summary>
        /// Get Shopping cart by id
        /// </summary>
        public ShoppingCart Get(long id)
        {
            return repository.Find(id);
        }
        
        /// <summary>
        /// Get Shopping cart for user
        /// </summary>
        public ShoppingCart Get(string userCartId)
        {
            return repository.Get(userCartId);
        }

        /// <summary>
        /// Get All Shopping Carts
        /// </summary>
        public IEnumerable<ShoppingCart> GetAll()
        {
            return repository.GetAll();
        }

        /// <summary>
        /// Add Shopping Cart
        /// </summary>
        public bool AddShoppingCart(IEnumerable<ShoppingCart> cart)
        {
            try
            {
                foreach (var shoppingCart in cart)
                {
                    repository.Add(shoppingCart);
                }
                repository.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Add Item to the cart
        /// </summary>
        public bool AddItemToCart(ShoppingCart cart)
        {
            try
            {
                repository.Add(cart);
                repository.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Update items quantities
        /// </summary>
        public bool SyncShoppingCart(ShoppingCartSearchRequest request)
        {
            var dbCartList = Get(request.UserCartId);
            if (dbCartList != null)
            {
                foreach (var shoppingCart in request.ShoppingCart.ShoppingCartItems)
                {
                    var cartItem = shoppingCart;
                    ShoppingCartItem listItem = dbCartList.ShoppingCartItems.FirstOrDefault(x => x.ProductId == cartItem.ProductId);
                    if (listItem != null)
                    {
                        listItem.Quantity += shoppingCart.Quantity;
                        itemRepository.Update(listItem);
                    }
                    else
                    {
                        shoppingCart.CartId = dbCartList.CartId;
                        itemRepository.Add(shoppingCart);
                    }
                }
                itemRepository.SaveChanges();
            }
            else
            {
                repository.Add(request.ShoppingCart);
                repository.SaveChanges();
            }
            return true;
        }

        /// <summary>
        /// Update Shopping Cart
        /// </summary>
        public bool UpdateShoppingCart(ShoppingCart cart)
        {
            try
            {
                repository.Update(cart);
                repository.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Shopping Cart
        /// </summary>
        public void DeleteShoppingCart(long cartId)
        {
            var cart = Get(cartId);
            repository.Delete(cart);
            repository.SaveChanges();
        }

        #endregion
    }
}
