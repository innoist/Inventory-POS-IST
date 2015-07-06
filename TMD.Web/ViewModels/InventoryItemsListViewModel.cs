using System.Collections.Generic;
using TMD.Models.RequestModels;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class InventoryItemsListViewModel
    {
        public InventoryItemsListViewModel()
        {
            Vendors = new List<VendorModel>();
        }
        public IEnumerable<InventoryItemModel> data { get; set; }
        public IEnumerable<VendorModel> Vendors { get; set; }
        /// <summary>
        /// Search Request
        /// </summary>
        public InventoryItemSearchRequest SearchRequest { get; set; }

        public int recordsTotal;
        public int recordsFiltered;
    }
}