using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Models.ResponseModels
{
    public sealed class InventoryItemSearchResponse
    {
        public InventoryItemSearchResponse()
        {
            InventoryItems = new List<InventoryItem>();
        }

        /// <summary>
        /// Inventory Items
        /// </summary>
        public IEnumerable<InventoryItem> InventoryItems { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        
        public int TotalCount { get; set; }

        public int FilteredCount { get; set; }

    }
}
