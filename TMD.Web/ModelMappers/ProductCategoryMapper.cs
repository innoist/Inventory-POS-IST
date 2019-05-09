using System.Linq;
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

        public static ProductCategoryModel CreateFromServerToClient(this ProductCategory source, bool headersOnly = true)
        {
            var response = new ProductCategoryModel
            {
                CategoryId = source.CategoryId,
                Description = source.Description,
                Name=source.Name,
                NameWithMainCategory = (source.ProductMainCategory != null ? source.ProductMainCategory.Name + " - " : "") + source.Name,
                MainCategoryId = source.MainCategoryId,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                ProductMainCategoryName = source.ProductMainCategory==null ?"": source.ProductMainCategory.Name
            };
            if (headersOnly)
            {
                return response;
            }
            response.Products = source.Products
                                      .Where(p => p.ProductImages.Any(pi => !string.IsNullOrEmpty(pi.ImagePath)))
                                      .OrderBy(p => p.Name)
                                      .Take(3)
                                      .Select(product => product.CreateFromServerToClient())
                                      .ToList();
            return response;
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