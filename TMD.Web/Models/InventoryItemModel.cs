using System.ComponentModel.DataAnnotations;

namespace TMD.Web.Models
{
    public class InventoryItemModel
    {
        public long ItemId { get; set; }

        [Required]
        [Display(Name = "Product Code")]
        public long ProductId { get; set; }

        [Required]
        [Display(Name = "Vendor")]
        public long VendorId { get; set; }
        [Range(-50, long.MaxValue, ErrorMessage = "Please enter valid quantity")]
        public long Quantity { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string Comments { get; set; }

        [Required]
        [Display(Name = "Purchasing Date")]
        public System.DateTime PurchasingDate { get; set; }

        [Required]
        [Display(Name = "Purchase Price")]
        public decimal PurchasePrice { get; set; }

        [Required]
        [Display(Name = "Sale Price")]
        public decimal SalePrice { get; set; }

        [Required]
        [Display(Name = "Min Sale Price Allowed")]
        public decimal MinSalePriceAllowed { get; set; }
    }
}