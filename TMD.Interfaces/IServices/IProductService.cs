using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IProductService
    {
        Product GetProduct(long productId);
        IEnumerable<Product> GetAllProducts();
        long AddProduct(Product product);
    }
}
