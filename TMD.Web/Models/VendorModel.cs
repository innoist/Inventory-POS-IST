using System.ComponentModel.DataAnnotations;

namespace TMD.Web.Models
{
    public class VendorModel
    {
        public long VendorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ContactNo { get; set; }
        public bool ActiveFlag { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
    }
}