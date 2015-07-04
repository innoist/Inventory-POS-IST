using System.Collections.Generic;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            ProductCategories = new List<ProductCategoryModel>();
        }
        public ProductModel ProductModel { get; set; }
        public IEnumerable<ProductCategoryModel> ProductCategories { get; set; }
    }
}