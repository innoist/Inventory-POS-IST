using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class InventoryItemService:IInventoryItemService
    {
        private readonly IInventoryItemRepositoy inventoryItemRepositoy;
        private readonly IProductRepository productRepository;
        private readonly IVendorRepository vendorRepository;

        public InventoryItemService(IInventoryItemRepositoy inventoryItemRepositoy,IProductRepository productRepository, IVendorRepository vendorRepository)
        {
            this.inventoryItemRepositoy = inventoryItemRepositoy;
            this.productRepository = productRepository;
            this.vendorRepository = vendorRepository;
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
            if (inventoryItem.ItemId>0)
                inventoryItemRepositoy.Update(inventoryItem);
            else
                inventoryItemRepositoy.Add(inventoryItem);
            inventoryItemRepositoy.SaveChanges();

            //Update Product Price etc
            UpdateProduct(inventoryItem);

            return inventoryItem.ItemId;
        }

        public InventoryItemSearchResponse GetInventoryItemSearchResponse(InventoryItemSearchRequest searchRequest)
        {
            return inventoryItemRepositoy.GetInventoryItemSearchResponse(searchRequest);
        }

        public InventoryItemResponse GetInventoryItemResponse(long? inventoryItemId)
        {
            InventoryItemResponse inventoryItemResponse=new InventoryItemResponse();
            if (inventoryItemId != null)
            {
                var inventoryItem = GetInventoryItem((long)inventoryItemId);
                if (inventoryItem != null)
                    inventoryItemResponse.InventoryItem = inventoryItem;
            }
            inventoryItemResponse.Vendors = vendorRepository.GetActiveVendors().ToList();
            return inventoryItemResponse;
        }

        private void UpdateProduct(InventoryItem inventoryItem)
        {
            var product = productRepository.Find(inventoryItem.ProductId);
            if (product == null || (product.PurchasePrice == inventoryItem.PurchasePrice && product.SalePrice == inventoryItem.SalePrice))
                return;

            product.PurchasePrice = inventoryItem.PurchasePrice;
            product.SalePrice = inventoryItem.SalePrice;

            productRepository.Update(product);
            productRepository.SaveChanges();
        }
    }
}
