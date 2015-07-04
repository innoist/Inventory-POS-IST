using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class InventoryItemService:IInventoryItemService
    {
        private readonly IInventoryItemRepositoy inventoryItemRepositoy;

        public InventoryItemService(IInventoryItemRepositoy inventoryItemRepositoy)
        {
            this.inventoryItemRepositoy = inventoryItemRepositoy;
        }

        public InventoryItem GetInventoryItem(long inventoryItemId)
        {
            return inventoryItemRepositoy.Find(inventoryItemId);
        }

        public IEnumerable<InventoryItem> GetAllInventoryItems()
        {
            return inventoryItemRepositoy.GetAll();
        }

        public long AddInventoryItem(InventoryItem inventoryItem)
        {
            inventoryItemRepositoy.Add(inventoryItem);
            inventoryItemRepositoy.SaveChanges();
            return inventoryItem.ItemId;
        }
    }
}
