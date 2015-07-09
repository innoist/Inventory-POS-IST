using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface IProductCategoryService
    {
        ProductCategory GetProductCategory(long productCategoryId);
        CreateCategoryResponseModel GetProductCategoryResponse(long? productCategoryId);
        IEnumerable<ProductCategory> GetAllProductCategories();
        long AddProductCategory(ProductCategory productCategory);
    }
}
