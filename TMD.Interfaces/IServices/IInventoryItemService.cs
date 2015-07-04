using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IInventoryItemService
    {
        InventoryItem GetInventoryItem(long inventoryItemId);
        IEnumerable<InventoryItem> GetAllInventoryItems();
        long AddInventoryItem(InventoryItem inventoryItem);
    }
}
