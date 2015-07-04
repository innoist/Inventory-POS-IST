using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product GetProduct(long productId)
        {
            return productRepository.Find(productId);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productRepository.GetAll().ToList();
        }

        public long AddProduct(Product product)
        {
            productRepository.Add(product);
            productRepository.SaveChanges();
            return product.ProductId;
        }
    }
}
