using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface IOrdersService
    {
        Order GetOrders(long orderId);
        IEnumerable<Order> GetAllOrders();

        long AddService(Order order);
        bool UpdateService(Order order);

        OrderSearchResponse GetOrdersSearchResponse(OrderSearchRequest searchRequest);
    }
}
