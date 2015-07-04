using System.Collections.Generic;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class InventoryItemViewModel
    {
        public IEnumerable<VendorModel> Vendors { get; set; }
        public InventoryItemModel InventoryItem { get; set; }
    }
}