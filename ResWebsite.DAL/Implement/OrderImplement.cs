using ResWebsite.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResWebsite.DAL.Entity;
using System.Diagnostics;

namespace ResWebsite.DAL.Implement
{
    public class OrderImplement : IOrder
    {
        RestaurantDbContext db = null;
        public OrderImplement()
        {
            db = new RestaurantDbContext();
        }
        public bool AddOrder(Order order)
        {
            try
            {
                if (order != null)
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public bool DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int orderId)
        {
            return db.Orders.Find(orderId);
        }

        public IEnumerable<Order> GetAllOrder()
        {
            return db.Orders;
        }

        public bool UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
        public void SaveChangeData()
        {
            db.SaveChanges();
        }

        
    }
}
