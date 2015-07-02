using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class ProductCategoryMapper
    {
        public static ProductCategory CreateFromClientToServer(this ProductCategoryModel source)
        {
            return new ProductCategory
            {
                CategoryId = source.CategoryId,
                Description = source.Description,
                Name = source.Name,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }

        public static ProductCategoryModel CreateFromServerToClient(this ProductCategory source)
        {
            return new ProductCategoryModel
            {
                CategoryId = source.CategoryId,
                Description = source.Description,
                Name = source.Name,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}