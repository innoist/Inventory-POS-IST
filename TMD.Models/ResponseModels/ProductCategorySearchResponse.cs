using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Models.ResponseModels
{
    /// <summary>
    /// Product Category Search Response
    /// </summary>
    public sealed class ProductCategorySearchResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ProductCategorySearchResponse()
        {
            ProductCategories = new List<ProductCategory>();
        }

        /// <summary>
        /// Product Categories
        /// </summary>
        public IEnumerable<ProductCategory> ProductCategories { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        
        public int TotalCount { get; set; }

        /// <summary>
        /// Filtered Count
        /// </summary>
        public int FilteredCount { get; set; }

    }
}
