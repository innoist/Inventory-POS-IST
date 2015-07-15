using System;
using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class OrdersService : IOrdersService
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


        public long AddService(Order order)
        {
            try
            {


                ordersRepository.Add(order);
                ordersRepository.SaveChanges();
                return order.OrderId;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool UpdateService(Order order)
        {
            try
            {
                ordersRepository.Update(order);
                
                ordersRepository.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                throw e;
                
            }
            return false;

        }

        public bool DeleteOrder(long orderId)
        {
            var order = ordersRepository.Find(orderId);
            if (order != null)
            {
                order.IsDeleted = true;
                ordersRepository.Update(order);
                ordersRepository.SaveChanges();
                return true;
            }
            return false;
        }


        public Models.ResponseModels.OrderSearchResponse GetOrdersSearchResponse(Models.RequestModels.OrderSearchRequest searchRequest)
        {
            return ordersRepository.GetOrdersSearchResponse(searchRequest);
        }
    }
}
