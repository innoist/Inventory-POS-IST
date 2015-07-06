using TMD.Models.Common;

namespace TMD.Models.RequestModels
{
    public class ProductCategorySearchRequest : GetPagedListRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public ProductCategoryByColumn ProductOrderBy
        {
            get
            {
                return (ProductCategoryByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
