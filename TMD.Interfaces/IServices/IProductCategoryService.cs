using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IProductCategoryService
    {
        ProductCategory GetProductCategory(long productCategoryId);
        IEnumerable<ProductCategory> GetAllProductCategories();
        long AddProductCategory(ProductCategory productCategory);
    }
}
