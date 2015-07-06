using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Models.ResponseModels
{
    public sealed class ProductResponse
    {
        public ProductResponse()
        {
            ProductCategories = new List<ProductCategory>();
        }

        /// <summary>
        /// Product Categories
        /// </summary>
        public IEnumerable<ProductCategory> ProductCategories { get; set; }

        public Product Product { get; set; }
    }
}
