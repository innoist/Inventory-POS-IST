using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IRepository
{
    public interface IProductCategoryRepository : IBaseRepository<ProductCategory, long>
    {
        ProductCategorySearchResponse GetAll(ProductCategorySearchRequest request);
    }
}
