using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IRepository
{
    public interface IProductRepository : IBaseRepository<Product, long>
    {
        ProductSearchResponse GetProductSearchResponse(ProductSearchRequest searchRequest);
        Product GetProductByAnyCode(string code, bool searchBarCode = true);
    }
}
