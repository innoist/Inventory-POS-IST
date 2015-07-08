using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IRepository
{
    public interface IOrdersRepository : IBaseRepository<Order, long>
    {
        OrderSearchResponse GetOrdersSearchResponse(OrderSearchRequest searchRequest);
    }
}
