namespace TMD.Models.DomainModels
{
    public class ProductConfiguration
    {
        public long Id { get; set; }
        public byte MaxAllowedDiscount { get; set; }
        public string Emails { get; set; }
        public string SecurityPassword { get; set; }
        public string ProductCodePrefix { get; set; }
    }
}
