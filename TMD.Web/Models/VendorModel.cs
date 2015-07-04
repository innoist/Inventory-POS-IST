namespace TMD.Web.Models
{
    public class VendorModel
    {
        public long VendorId { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public bool ActiveFlag { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }
    }
}