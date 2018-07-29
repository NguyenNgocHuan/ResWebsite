using System;
using System.Collections.Generic;
using ResWebsite.DAL.Entity;
using ResWebsite.DAL.Interface;
using System.Data.Entity;
using System.Linq;
using System.Diagnostics;

namespace ResWebsite.DAL.Implement
{
    public class OrderServiceDetailImplement : IOrderServiceDetail
    {
        RestaurantDbContext db = new RestaurantDbContext();
        public bool AddServiceOrderDetail(OrderServiceDetail orderServiceDetail)
        {
            
           OrderServiceDetail s = db.OrderServiceDetails.Where(x => x.OrderId == orderServiceDetail.OrderId
                && x.ServiceId.Equals((orderServiceDetail.ServiceId))).FirstOrDefault();
                if (s != null)
                {
                s.Quantity = s.Quantity + 1;
                if (UpdateServiceOrderDetail(s))
                {
                    return true;
                }
                return false;
            }
            else
            {
                try
                {
                    db.OrderServiceDetails.Add(orderServiceDetail);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                    throw;
                }
            }
            
        }

        public bool DeleteServiceOrderDetail(int orderId, string OrderServiceDetailId)
        {

            try
            {
                var service = db.OrderServiceDetails.Where(x => x.OrderId == orderId && x.ServiceId.Equals(OrderServiceDetailId)).FirstOrDefault();
                if (service != null)
                {
                    db.OrderServiceDetails.Remove(service);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<OrderServiceDetail> GetAllOrderServiceDetail()
        {
            return db.OrderServiceDetails;
        }

        public IEnumerable<OrderServiceDetail> GetServicesOrderDetailByOrderId(int orderId)
        {
            return db.OrderServiceDetails.Where(x => x.OrderId == orderId);
        }

        public bool UpdateServiceOrderDetail(OrderServiceDetail orderServiceDetail)
        {
            try
            {
                db.Entry(orderServiceDetail).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }
        public double? GetPriceServiceOrder(int orderId)
        {
            var list = db.OrderServiceDetails.Where(x => x.OrderId == orderId);
            double? total = 0.0;
            foreach (var i in list)
            {
                total += (double)i.Price * i.Quantity;
            }
            Trace.WriteLine("cksdjcjsd" + total);
            return total;
        }
    }
}
