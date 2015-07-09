using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class ProductCategoryMapper
    {
        #region Product Category Mappers
        public static ProductCategory CreateFromClientToServer(this ProductCategoryModel source)
        {
            return new ProductCategory
            {
                CategoryId = source.CategoryId,
                Description = string.IsNullOrEmpty(source.Description) ? "" : source.Description,
                Name = source.Name,
                MainCategoryId = source.MainCategoryId,
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
                Name=source.Name,
                NameWithMainCategory = (source.ProductMainCategory != null ? source.ProductMainCategory.Name + " - " : "") + source.Name,
                MainCategoryId = source.MainCategoryId,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
        #endregion

        #region Product Main-Category Mappers
        public static ProductMainCategory CreateFromClientToServer(this ProductMainCategoryModel source)
        {
            return new ProductMainCategory
            {
                CategoryId = source.CategoryId,
                Description = string.IsNullOrEmpty(source.Description) ? "" : source.Description,
                Name = source.Name,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }

        public static ProductMainCategoryModel CreateFromServerToClient(this ProductMainCategory source)
        {
            return new ProductMainCategoryModel
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
        #endregion
    }
}