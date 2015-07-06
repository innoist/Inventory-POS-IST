﻿using System.Collections.Generic;
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

        public InventoryItemService(IInventoryItemRepositoy inventoryItemRepositoy,IProductRepository productRepository)
        {
            this.inventoryItemRepositoy = inventoryItemRepositoy;
            this.productRepository = productRepository;
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
