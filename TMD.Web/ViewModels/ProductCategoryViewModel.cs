using System.Collections.Generic;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class ProductCategoryViewModel
    {
        public ProductCategoryViewModel()
        {
            ProductMainCategories = new List<ProductMainCategoryModel>();
        }
        public ProductCategoryModel ProductCategoryModel { get; set; }
        public IEnumerable<ProductMainCategoryModel> ProductMainCategories { get; set; }
    }
}