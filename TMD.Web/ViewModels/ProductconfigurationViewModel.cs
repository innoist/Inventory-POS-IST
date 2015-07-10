using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class ProductConfigurationViewModel
    {        
        public IEnumerable<VendorModel> vendorModel { get; set; }
        /// <summary>
        /// Search Request
        /// </summary>


        public ProductConfiguration Configuration { get; set; }
    }
}