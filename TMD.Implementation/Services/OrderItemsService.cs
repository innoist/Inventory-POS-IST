using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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


        public long AddService(OrderItem orderItem)
        {
            orderItemsRepository.Add(orderItem);
            orderItemsRepository.SaveChanges();
            return orderItem.OrderItemId;
        }

        public bool UpdateService(OrderItem orderItem)
        {
           orderItemsRepository.Update(orderItem);
            orderItemsRepository.SaveChanges();
            return true;
        }


        public void AddUpdateService(Order order)
        {
            foreach (var item in order.OrderItems)
            {
                if (item.OrderItemId <= 0)
                    AddService(item);
                else
                    UpdateService(item);
            }
        }
    }
}
