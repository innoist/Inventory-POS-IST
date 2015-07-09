using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Models.DomainModels;
using TMD.Models.LoggerModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class OrderItemMapper
    {

        public static OrderItemModel CreateFromServerToClient(this OrderItem source)
        {
            return new OrderItemModel
            {
                OrderItemId = source.OrderItemId,
                OrderId =  source.OrderId,
                AmountGiven = source.AmountGiven,
                Discount = source.Discount,
                PurchasePrice = source.PurchasePrice,
                ProductId =  source.ProductId,
                SalePrice = source.SalePrice,
                MinSalePriceAllowed = source.MinSalePriceAllowed,
                Quantity = source.Quantity,
                

                Comments = source.Comments,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                Product = source.Product.CreateFromServerToClient()
               
            };
        }
        public static OrderItem CreateFromClientToServer(this OrderItemModel source,long orderId)
        {
            return new OrderItem
            {
                OrderItemId = source.OrderItemId,
                OrderId = orderId,
                AmountGiven = source.AmountGiven,
                Discount = byte.Parse( source.Discount.ToString()),
                PurchasePrice = source.PurchasePrice,
                ProductId = source.ProductId,
                SalePrice = source.SalePrice,
                MinSalePriceAllowed = source.MinSalePriceAllowed,
                Quantity = source.Quantity,

                Comments = source.Comments,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
                

            };
        }
    }
}