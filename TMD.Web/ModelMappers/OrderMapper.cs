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
                OrderItems = source.OrderItems.Select(x => x.CreateFromClientToServer(source.OrderId)).ToList()
            };
        }
    
    
    //FOR LIST VIEW

        public static OrderListViewModel CreateFromServerToLVClient(this Order source)
        {
            var hostURL = "http://" + HttpContext.Current.Request.Url.Host.ToLower() + "/";//ConfigurationManager.AppSettings["HostURL"];
            var item = source.OrderItems.ToList();
            var customer = source.Customer;
            return new OrderListViewModel
            {
                IsModified = source.IsModified,
                CustomerId = source.CustomerId,
                Comments = source.Comments,
                OrderId = @"<a title='Click to open order' href='" + hostURL + "Order/Create?id=" + source.OrderId + "'> " + source.OrderId + "</a>",
                OrderOriginalId = source.OrderId,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate.ToShortDateString(),
                RecCreatedDateFormatted= String.Format("{0:ddd, MMM d, yyyy}", source.RecCreatedDate),
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                TotalDiscount = item.Sum(x=>x.Discount),
                TotalSale = double.Parse(item.Sum(x => x.SalePrice * x.Quantity).ToString()),
                TotalItems = item.Sum(x => x.Quantity),
                CustomerName = source.CustomerId>0 ? source.Customer.Name : "",
                CustomerEmail = source.CustomerId > 0 ? source.Customer.Email : "",
                CustomerPhone = source.CustomerId > 0 ? source.Customer.Phone : "",
            };
        }
    }
}