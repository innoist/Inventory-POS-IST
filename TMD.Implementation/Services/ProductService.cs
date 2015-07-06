using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IInventoryItemRepositoy inventoryItemRepositoy;
        private readonly IOrderItemsRepository orderItemsRepository;
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductService(IProductRepository productRepository, IInventoryItemRepositoy inventoryItemRepositoy, IOrderItemsRepository orderItemsRepository, IProductCategoryRepository productCategoryRepository)
        {
            this.productRepository = productRepository;
            this.inventoryItemRepositoy = inventoryItemRepositoy;
            this.orderItemsRepository = orderItemsRepository;
            this.productCategoryRepository = productCategoryRepository;
        }

        public Product GetProduct(long productId)
        {
            return productRepository.Find(productId);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productRepository.GetAll().ToList();
        }

        public long SaveProduct(Product product)
        {
            if(product.ProductId>0)
                productRepository.Update(product);
            else
                productRepository.Add(product);
            
            productRepository.SaveChanges();
            return product.ProductId;
        }

        public long GetAvailableProductItem(long productId)
        {
            var itemInInventory = inventoryItemRepositoy.GetItemCountInInventory(productId);
            var itemInOrders = orderItemsRepository.GetItemCountInOrders(productId);
            return itemInInventory - itemInOrders;
        }

        public ProductSearchResponse GetProductSearchResponse(ProductSearchRequest searchRequest)
        {
            return productRepository.GetProductSearchResponse(searchRequest);
        }

        public ProductResponse GetProductResponse(long? productId)
        {
            ProductResponse responseResult = new ProductResponse();
            if (productId != null)
            {
                var product = GetProduct((long)productId);
                if (product != null)
                    responseResult.Product = product;
            }
            responseResult.ProductCategories = productCategoryRepository.GetAll().ToList();
            return responseResult;
        }
    }
}
