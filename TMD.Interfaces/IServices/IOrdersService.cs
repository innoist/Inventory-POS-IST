using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IOrdersService
    {
        Order GetOrders(long orderId);
        IEnumerable<Order> GetAllOrders();

        long AddService(Order order);
        bool UpdateService(Order order);

      

    }
}
