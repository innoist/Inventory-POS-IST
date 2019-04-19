using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMD.Web.Models
{
    public class ProductImageModel
    {
        public long ItemImageID { get; set; }
        public long ProductId { get; set; }
        public string ImagePath { get; set; }
    }
}