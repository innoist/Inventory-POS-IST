using System.ComponentModel.DataAnnotations;

namespace TMD.Models.DomainModels
{
    public class ProductConfiguration
    {
        public long Id { get; set; }
        [Range(0, 99, ErrorMessage = "Value must be less than 100.")]
        public byte MaxAllowedDiscount { get; set; }
        public string Emails { get; set; }
        public string SecurityPassword { get; set; }
        public string ProductCodePrefix { get; set; }
        public string Comments { get; set; }

        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

    }
}
