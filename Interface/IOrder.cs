using OnDemandCarWashSystemAPI.Models;
using System.Collections.Generic;

namespace OnDemandCarWashSystemAPI.Interface
{
    public interface IOrder
    {
        List<Order> GetAllOrder();
        Order GetOrder(int id);
        public string AddOrder(Order order);
        public string UpdateOrder(Order order);
        public string DeleteOrder(int id);
    }
}

