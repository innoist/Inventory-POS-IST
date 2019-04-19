namespace TMD.Models.DomainModels
{
    public class ProductImage
    {
        public long ItemImageID { get; set; }
        public long ProductId { get; set; }
        public string ImagePath { get; set; }

        public virtual Product Product { get; set; }
    }
}
