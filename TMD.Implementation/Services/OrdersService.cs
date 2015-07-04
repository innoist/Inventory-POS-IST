using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class OrdersService:IOrdersService
    {
        private readonly IOrdersRepository ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }



        public Order GetOrders(long orderId)
        {
            return ordersRepository.Find(orderId);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            throw new System.NotImplementedException();
        }
    }
}
