using System.Collections.Generic;

namespace TMD.Models.DomainModels
{
    public class ProductCategory
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public long? MainCategoryId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ProductMainCategory ProductMainCategory { get; set; }
    }
}
