using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Models.ResponseModels
{
    public class CreateCategoryResponseModel
    {
        public ProductCategory ProductCategory { get; set; }
        public IEnumerable<ProductMainCategory> ProductMainCategories { get; set; }
    }
}
