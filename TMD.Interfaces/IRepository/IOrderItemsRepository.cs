﻿using System;
using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IOrderItemsRepository : IBaseRepository<OrderItem, long>
    {
        long GetItemCountInOrders(long productId);
        IEnumerable<OrderItem> GetOrderItemsReport(string productCode, DateTime startDate, DateTime endDate);
        IEnumerable<OrderItem> GetSalesSummaryReport(DateTime startDate, DateTime endDate);
    }
}
