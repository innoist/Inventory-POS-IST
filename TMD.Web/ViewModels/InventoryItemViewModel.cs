using System.Collections.Generic;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class InventoryItemViewModel
    {
        public InventoryItemViewModel()
        {
            Vendors = new List<VendorModel>();
        }
        public IEnumerable<VendorModel> Vendors { get; set; }
        public InventoryItemModel InventoryItem { get; set; }
    }
}