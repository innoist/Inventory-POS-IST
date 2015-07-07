using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IOrderItemService
    {
        IEnumerable<OrderItem> GetOrderItems(long orderId);

        OrderItem GetOrderItemById(long orderItemId);
        
        IEnumerable<OrderItem> GetAllOrderItems();
    }
}
