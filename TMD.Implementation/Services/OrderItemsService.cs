using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class OrderItemsService:IOrderItemService
    {
        private readonly IOrderItemsRepository orderItemsRepository;

        public OrderItemsService(IOrderItemsRepository orderItemsRepository)
        {
            this.orderItemsRepository = orderItemsRepository;
        }





        public IEnumerable<OrderItem> GetOrderItems(long orderId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<OrderItem> GetAllOrderItems()
        {
            throw new System.NotImplementedException();
        }


        public OrderItem GetOrderItemById(long orderItemId)
        {
            return orderItemsRepository.Find(orderItemId);
        }
    }
}
