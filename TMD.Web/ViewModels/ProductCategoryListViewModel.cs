using System.Collections.Generic;
using TMD.Models.RequestModels;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class ProductCategoryListViewModel
    {        
        public IEnumerable<ProductCategoryModel> data { get; set; }
        /// <summary>
        /// Search Request
        /// </summary>
        public ProductCategorySearchRequest SearchRequest { get; set; }

        public int recordsTotal;
        public int recordsFiltered;
    }
}