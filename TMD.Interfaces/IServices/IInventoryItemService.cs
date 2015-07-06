using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface IInventoryItemService
    {
        InventoryItem GetInventoryItem(long inventoryItemId);
        IEnumerable<InventoryItem> GetAllInventoryItems();
        long AddInventoryItem(InventoryItem inventoryItem);
        InventoryItemSearchResponse GetInventoryItemSearchResponse(InventoryItemSearchRequest searchRequest);
        InventoryItemResponse GetInventoryItemResponse(long? inventoryItemId);
    }
}
