using System.Collections.Generic;
using TMD.Models.RequestModels;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class ProductsListViewModel
    {
        public ProductsListViewModel()
        {
            ProductCategories = new List<ProductCategoryModel>();
        }
        public IEnumerable<ProductModel> data { get; set; }
        public IEnumerable<ProductCategoryModel> ProductCategories { get; set; }
        /// <summary>
        /// Search Request
        /// </summary>
        public ProductSearchRequest SearchRequest { get; set; }

        public int recordsTotal;
        public int recordsFiltered;
    }
}