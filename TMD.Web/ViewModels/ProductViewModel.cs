using System.Collections.Generic;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class ProductViewModel
    {
        public ProductModel ProductModel { get; set; }
        public IEnumerable<ProductCategoryModel> ProductCategoryModel { get; set; }
    }
}