using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class OrderMapper
    {
        public static OrderModel CreateFromServerToClient(this Order source)
        {
            return new OrderModel
            {
               IsModified = source.IsModified,
               CustomerId = source.CustomerId,
                Comments = source.Comments,
                OrderId =  source.OrderId,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                Customer = source.Customer!=null ? source.Customer.CreateFromServerToClient() : new CustomerModel(),
                OrderItems = source.OrderItems.Select(x=>x.CreateFromServerToClient()).ToList()
            };
        }

        public static Order CreateFromClientToServer(this OrderModel source)
        {
            return new Order
            {
                IsModified = source.IsModified,
                CustomerId = source.CustomerId,
                Comments = source.Comments,
                OrderId = source.OrderId,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                OrderItems = source.OrderItems.Select(x => x.CreateFromClientToServer()).ToList()
            };
        }
    }
}