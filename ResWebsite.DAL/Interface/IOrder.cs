using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface
{
    public interface IOrder
    {
        IEnumerable<Order> GetAllOrder();
        bool AddOrder(Order order);
        bool UpdateOrder(Order order);
        bool DeleteOrder(int orderId);
        Order GetOrderById(int orderId);
    }
}
