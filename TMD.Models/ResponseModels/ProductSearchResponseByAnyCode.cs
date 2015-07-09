using TMD.Models.DomainModels;

namespace TMD.Models.ResponseModels
{
    public class ProductSearchResponseByAnyCode
    {
        public Product Product { get; set; }
        public long AvailableItems { get; set; }
    }
}
