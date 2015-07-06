using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Models.ResponseModels
{
    public sealed class InventoryItemResponse
    {
        public InventoryItemResponse()
        {
            Vendors = new List<Vendor>();
        }

        /// <summary>
        /// Inventory Vendors
        /// </summary>
        public IEnumerable<Vendor> Vendors { get; set; }
        public InventoryItem InventoryItem { get; set; }
    }
}
