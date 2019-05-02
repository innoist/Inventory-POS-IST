using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            ProductCategories = new List<ProductCategoryModel>();
            //ProductModel.ProductImages = new List<ProductImageModel>();
        }
        public ProductModel ProductModel { get; set; }
        public IEnumerable<ProductCategoryModel> ProductCategories { get; set; }
        //public List<ProductImageModel> ProductImages { get; set; }

    }

    public class ProductImageModel
    {
        public long ImageId { get; set; }
        public long ProductId { get; set; }
        public string ItemImagePath { get; set; }
    }
}