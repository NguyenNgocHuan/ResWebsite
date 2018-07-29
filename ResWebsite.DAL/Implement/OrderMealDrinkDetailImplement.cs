using System;
using System.Collections.Generic;
using ResWebsite.DAL.Entity;
using ResWebsite.DAL.Interface;
using System.Data.Entity;
using System.Linq;
using System.Diagnostics;

namespace ResWebsite.DAL.Implement
{
    public class OrderMealDrinkDetailImplement : IOrderMealDrinkDetail
    {
        RestaurantDbContext db = new RestaurantDbContext();
        public bool AddMealDrinkOrderDetail(OrderMealDrinkDetail orderMealDrinkDetail)
        {
            OrderMealDrinkDetail m = db.OrderMealDrinkDetails.Where(x => x.OrderId == orderMealDrinkDetail.OrderId 
                && x.MealDrinkId.Equals(orderMealDrinkDetail.MealDrinkId)).FirstOrDefault();

            if (m != null)
            {
                m.Quantity += orderMealDrinkDetail.Quantity;

                if (UpdateOrderDetail(m))
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            else {
                try
                {
                    db.OrderMealDrinkDetails.Add(orderMealDrinkDetail);
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

        public bool DeleteOrderMealDrinkDetailDAL(int orderId, string OrderMealDrinkDetailId)
        {
            try
            {
                var mealDrink = db.OrderMealDrinkDetails.Where(x => x.OrderId == orderId && x.MealDrinkId.Equals(OrderMealDrinkDetailId)).FirstOrDefault();
                if (mealDrink != null)
                {
                    db.OrderMealDrinkDetails.Remove(mealDrink);
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

        public IEnumerable<OrderMealDrinkDetail> GetAllOrderMealDrinkDetail()
        {
            return db.OrderMealDrinkDetails;
        }

        public IEnumerable<OrderMealDrinkDetail> GetOrderMealDrinkDetailByOrderId(int orderId)
        {
            return db.OrderMealDrinkDetails.Where(x => x.OrderId == orderId).ToList();
        }

        public bool UpdateOrderDetail(OrderMealDrinkDetail orderMealDrinkDetail)
        {
            try
            {
                db.Entry(orderMealDrinkDetail).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }

        public decimal GetPriceMealDrinkOrder(int orderId)
        {
                var list = db.OrderMealDrinkDetails.Where(x=>x.OrderId == orderId);
                decimal total = 0;
                foreach (var i in list)
                {
                    total += (decimal)i.Price * (decimal)i.Quantity;
                }
            return total;
        }

        public void SaveChangeData()
        {
            db.SaveChanges();
        }
        
    }
}
