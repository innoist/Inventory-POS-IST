using System.ComponentModel.DataAnnotations;

namespace TMD.Web.Models
{
    public class ProductModel
    {
        
        public long ProductId { get; set; }
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }
        [Display(Name = "Bar Code")]
        public string ProductBarCode { get; set; }
        [Display(Name = "Purchase Price")]
        public decimal PurchasePrice { get; set; }
        [Display(Name = "Sale Price")]
        public decimal SalePrice { get; set; }
        [Display(Name = "Minimum Sale Price Allowed")]
        public decimal MinSalePriceAllowed { get; set; }
        [Display(Name = "Category")]
        public long CategoryId { get; set; }
        [Display(Name = "Vendor")]
        public long VendorId { get; set; }
        public string Comments { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
    }
}