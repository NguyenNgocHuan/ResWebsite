using ResWebsite.DAL.Implement;
using System;
using System.Collections.Generic;
using ResWebsite.DAL.Entity;

namespace ResWebsite.BLL.Bussiness
{
    public class OrderBLL 
    {
        OrderImplement dal = new OrderImplement();
        public bool AddOrder(Order order)
        {
            if (dal.AddOrder(order))
                return true;
            return false;
        }

        public bool DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int orderId)
        {
            if (orderId > 0)
                return dal.GetOrderById(orderId);
            return null;
        }

        public IEnumerable<Order> GetAllOrder()
        {
            return dal.GetAllOrder();
        }

        public bool UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
        public void SaveChangeOrderDb()
        {
            dal.SaveChangeData();
        }
       
        }
}
